using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Yarn.Unity;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// A Major script that handles significant variables and actions/events across all 
/// scenes of the game. To be placed on a DO NOT DESTROY Object. This is the primary 
/// event broadcaster and repository of Yarn Commands.
/// </summary>

public class VariableTracker : MonoBehaviour
{
    //Yarn Access
    private InMemoryVariableStorage varStore;

    [Header("Game Management Variables")]
    public KeyCode roomKey = KeyCode.P;
    public bool isInUI = false;
    public bool isInRoom = false;
    public bool isElevatorLoading = false;
    public bool isElevatorIntentToGo = false;
    //public int currentDay;
    //should match the SceneExit game object "scenePauseTime"
    public float roomLoadPauseTime = 2f;
    //Keys are tracked via addition of strings to the list. The string must match
    //the portal Game Object name to unlock--see SceneExit.cs
    public List<string> keysOwned;
    public bool HasKey(string key)
    {
        return keysOwned.Contains(key);
    }

    [Header("Inventory Items")]
    public bool beeModule;

    [Header("Dialog UI")]
    public TMP_FontAsset playerFont;
    public TMP_FontAsset defaultFont;
    public TMP_FontAsset conciergeFont;
    public TMP_FontAsset yonicaFont;
    public TMP_FontAsset jssFont;
    public TMP_FontAsset currentFont;
    private DialogueRunner dialogueRunner;
    private TMP_Text currentText;
    private Image playerIcon;
    private Image conciergeIcon;
    private Image yonicaIcon;

    //Dialog History Tracker
    private List<string> dialogueHistory = new List<string>();

    //Events////////////////////
    public event Action onGiveKey;
    public event Action onPause;
    public event Action onLoad;
    public event Action onWFCScene;
    public event Action onNormScene;
    public event Action onElevOpen;
    public event Action onIntroFade;
    public event Action onForceUIFade;
    //public event Action<int> onShowDay;
    public event Action onBedUI;
    public event Action onSuitcaseUI;
    public event Action onBiblioUI;
    public event Action onObjectInteract;
    public event Action onObjectExit;
    //public event Action onDialogueReassert;
    public event Action onJSSInteractWBee;
    //public event Action<string> onQRShow;

    #region MONOBEHAVIOR
    private void Awake()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();

        if (FindObjectsOfType<EventSystem>().Length > 1)
        {
            Destroy(gameObject);  // Or destroy the clone that shouldn't persist
            return;
        }

    }
    private void Start()
    {
        varStore = GameObject.Find("Dialogue System").GetComponent<InMemoryVariableStorage>();

        currentText = GameObject.Find("Text").GetComponent<TMP_Text>();
        
        playerIcon = GameObject.Find("Player Icon").GetComponent<Image>();
        playerIcon.enabled = false;
        conciergeIcon = GameObject.Find("Concierge Icon").GetComponent<Image>();
        conciergeIcon.enabled = false;
        yonicaIcon = GameObject.Find("Yonica Icon").GetComponent<Image>();
        yonicaIcon.enabled = false;
        //onShowDay?.Invoke(currentDay);
    }
// Auto runs the custom func below when a scene loads
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Update()
    {
        // Teleports to hotel room or shows pause depending on having a key
        if (Input.GetKeyDown(roomKey) && HasKey("HotelRoom") && isInUI == false && isInRoom == false)
        {
            GoToRoom();
        }
        else if(Input.GetKeyDown(roomKey) && isInUI == false)
        {
            PauseFunc();
        }

        //Debug Function to see if entrances and exits are alligning
        //if (Input.GetKey(KeyCode.I))
        //{
        //    Debug.Log("Last Exit Name: " + PlayerPrefs.GetString("LastExitName"));
        //    Debug.Log("New Scene: " + PlayerPrefs.GetString("NewScene"));
        //}
    }
    #endregion MONOBEHAVIOR

    #region CUSTOM FUNCTIONS
    //Specific functions to call for given scenes
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Updates isInRoom bool at beginning of scene depending on scene name. 
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Room")
        {
            isInRoom = true;
        }
        else
        {
            isInRoom = false;
        }
        
        if (sceneName == "BackHalls")
        {
            WFCCharAdjuster();
        }
        else
        {
            NormSceneAdjuster();
        }

        if (sceneName == "Intro")
        {
            IntroSceneControl();
        }
        else
        {
            FadeIntroUI();
        }

        ForceUIFade();
        //Debug.Log("OnSceneLoaded called once");
        StartCoroutine(ElevatorLoadReset());
    }
    
    public void GoToRoom()
    {
        if (isInRoom)
        {
            ShowLoad();
            StartCoroutine(LeaveRoomCountdown());
        }
        else
        {
            ShowLoad();
            StartCoroutine(RoomLoadCountdown());
        }
    }
    
    private void WFCCharAdjuster()
    {
        onWFCScene?.Invoke();
        Debug.Log("Invoked onWFCScene");

    }
    private void NormSceneAdjuster()
    {
        onNormScene?.Invoke();
        Debug.Log("Invoked onNormScene");
    }

    public void ShowLoad()
    {
        onLoad?.Invoke();
    }

    public void FadeIntroUI()
    {
        onIntroFade?.Invoke();
    }

    public void ForceUIFade()
    {
        onForceUIFade?.Invoke();
    }

    public void PauseFunc()
    {
        onPause?.Invoke();
    }

    public void ElevDoorOpenOnly()
    {
        //Note this is a different version than the yarn func which includes and extra bool flip for
        onElevOpen?.Invoke();
    }

    public void GiveKey()
    {
        onGiveKey?.Invoke();
    }

    public void BedUI()
    {
        isInUI = true;
        onBedUI?.Invoke();
        onObjectInteract?.Invoke();
    }

    public void SuitcaseUI()
    {
        isInUI = true;
        onSuitcaseUI?.Invoke();
        onObjectInteract?.Invoke();
    }

    public void BiblioUI()
    {
        isInUI = true;
        onBiblioUI?.Invoke();
        onObjectInteract?.Invoke();
    }

    public void IntroSceneControl()
    {
        onObjectInteract?.Invoke();
    }

    public void ObjectUIExit()
    {
        isInUI = false;
        onObjectExit?.Invoke();
    }

    /*We could probably get around all the equipping and unequipping if we made this a numeric
     * system where pressing the button increments a number and a script checks the number and 
     * equips the proper inventory item related to that number. This works only if we want 1 
     * item at a time*/
    public void beeModuleEquip()
    {
        beeModule = true;
        if (beeModule)
        {
            currentText.font = jssFont;
            onJSSInteractWBee?.Invoke();
        }
    }

    public void beeModuleUnequip()
    {
        beeModule = false;
        if (beeModule == false)
        {
            textNormalizer();
        }
    }    

    public void textNormalizer()
    {
        currentText.font = defaultFont;
    }

    //Called when the player ray hits JSS
    public void JSSBeeTextSetter()
    {
        if (beeModule)
        {
            textNormalizer();
        }
        else
        {
            currentText.font = jssFont;
            Debug.Log("event broadcast");
        }
    }
    //Called on exit button (WOULD NEED TO ALSO BE CALLED ON LAST LINE PROBABLY)
    public void JSSBeeTextResetter()
    {
        if (beeModule)
        {
            currentText.font = jssFont;
        }
        else
        {
            textNormalizer();
        }
    }

    #endregion CUSTOM FUNCTIONS

    #region COROUTINES
    public IEnumerator RoomLoadCountdown()
    {
        yield return new WaitForSeconds(roomLoadPauseTime);
        //Ensures player teleporting in is set in the correct place
        PlayerPrefs.SetString("LastExitName", "AtriumRoom");
        SceneManager.LoadScene("Room");
        isInRoom = true;
    }

    public IEnumerator LeaveRoomCountdown()
    {
        yield return new WaitForSeconds(roomLoadPauseTime);
        SceneManager.LoadScene(PlayerPrefs.GetString("NewScene"));
        isInRoom = false;
    }

    public IEnumerator ElevatorLoadReset()
    {
        yield return new WaitForSeconds(5);
        isElevatorLoading = false;
    }

    #endregion COROUTINES

    #region YARN COMMANDS
    [YarnCommand("BasicRoom")]
    public void basicRoom()
    {
        keysOwned.Add("HotelRoom");
        //isRoomKeyed = true;
        GiveKey();
    }

    /// <summary>
    /// SOMEWHERE here there needs to be a yarn command to set the playerprefs scene exit
    /// This would be done through convo with the elevator attendant but checked by the collider 
    /// along the elevator track.
    /// 
    ///         if (other.gameObject.CompareTag("Player") && !isLocked)
//        {
//            PlayerPrefs.SetString("LastExitName", exitName);
//            //the function of "NewScene" is actually to be read by the pause script
//            //to spawn you back from pause into the right place
//            PlayerPrefs.SetString("NewScene", sceneToLoad);
//            StartCoroutine(LoadCountdown());
//}
/// </summary> 

//[YarnCommand("ElevatorExitAssigner")]
//    public void exitAssign(string exitToGoTo)
//    {
//        PlayerPrefs.SetString("LastExitName", exitToGoTo);
//    }

    [YarnCommand ("ElevatorSceneAssigner")]
    public void sceneAssign(string exitToGoTo, string sceneToGoTo)
    {
        Debug.Log("Exit: " + exitToGoTo);
        Debug.Log("Scene: " + sceneToGoTo);
        PlayerPrefs.SetString("LastExitName", exitToGoTo);
        PlayerPrefs.SetString("NewScene", sceneToGoTo);
    }

    [YarnCommand ("DoorOpener")]
    public void elevDoorOpen()
    {
        isElevatorIntentToGo = true;
        onElevOpen?.Invoke();
    }

    [YarnCommand("PlayerTalking")]
    public void playerText()
    {
        currentText.font = playerFont;
        playerIcon.enabled = true;
        conciergeIcon.enabled = false;
        yonicaIcon.enabled = false;
    }

    [YarnCommand("ConciergeTalking")]
    public void conciergeText()
    {
        currentText.font = defaultFont;
        conciergeIcon.enabled = true;
        playerIcon.enabled = false;
        yonicaIcon.enabled = false;
    }

    [YarnCommand("YonicaTalking")]
    public void yonicaText()
    {
        //currentText.font = defaultFont;
        yonicaIcon.enabled = true;
        playerIcon.enabled = false;
        conciergeIcon.enabled = false;
    }
    
    [YarnCommand("NoneTalking")]
    public void noneText()
    {
        //currentFont = yonicaFont;
        yonicaIcon.enabled = false;
        playerIcon.enabled = false;
        conciergeIcon.enabled = false;
    }
    #endregion YARN COMMANDS

}