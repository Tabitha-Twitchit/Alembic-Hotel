using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorSceneLoader : MonoBehaviour
{
    private string sceneToLoad;
    //private string exitName;
    private GameObject loadCard;
    public float scenePauseTime = 2f;

    private VariableTracker varTracker;
    public bool isLocked = false;
    //[SerializeField] private static bool isLoading = false;
    //private string thisDoorLockName;

    private GameObject player;
    
    private void Start()
    {
        loadCard = GameObject.Find("Loadscreen Group");
        //thisDoorLockName = gameObject.name;
        varTracker = GameObject.Find("GameManager").GetComponent<VariableTracker>();
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Player Found");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !isLocked && !varTracker.isElevatorLoading)
        {
            // note this is to control accidental reloads of the scene when player falls through the elevator
            // after the parenting is removed. The bool is reset in a coroutine, ElevatorLoadReset() on the
            // varTracker, which is called onSceneLoaded, the delay thereby preventing the bool reset, retrigger.
            varTracker.isElevatorLoading = true;
            //Debug.Log("Player Parent?: " + player.transform.parent?.name);
            sceneToLoad = PlayerPrefs.GetString("NewScene");
            player.transform.SetParent(null);
            DontDestroyOnLoad(player);
            //Debug.Log("Player Parent?: " + player.transform.parent?.name);
            StartCoroutine(LoadCountdown());
        }
    }

    public IEnumerator LoadCountdown()
    {
        SceneLoadCardFade receiver = loadCard.GetComponent<SceneLoadCardFade>();
        if (receiver != null)
        {
            StartCoroutine(receiver.FadeIn());
        }
        yield return new WaitForSeconds(scenePauseTime);
        SceneManager.LoadScene(sceneToLoad);
        //Debug.Log("Load Countdown Run: " + ++count);
    }
}
