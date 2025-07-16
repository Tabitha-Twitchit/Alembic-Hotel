using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Controls access to the adamic console. This lives in its own script rather 
/// than main char controller because it must deactivate the controller to 
/// allow the cursor to take over. 
/// </summary>
public class ConsoleControl : MonoBehaviour
{
    public KeyCode console = KeyCode.BackQuote;
    public int adamicThreshold;
    
    private GameObject consoleScreen;
    private TMP_InputField input;
    private bool isConsoleOn = false;
    
    //The first person script
    private FirstPersonController firstPersonController;
    //The character controller component related to the first person script
    private CharacterController player;
   // The FLying script for noClip
    private FlyingController flyingController;
    private Pickup_w_counter packetCounter;

    public bool isNoClip = false;

    // Start is called before the first frame update
    void Start()
    {
        consoleScreen = GameObject.Find("UI Input Window");
        consoleScreen.SetActive(false);
        input = consoleScreen.GetComponentInChildren<TMP_InputField>();
        packetCounter = GetComponent<Pickup_w_counter>();
        firstPersonController = GetComponent<FirstPersonController>();
        player = GetComponent<CharacterController>();
        flyingController = GetComponent<FlyingController>();
        input.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(console)) //&& packetCounter.count > adamicThreshold)
        {
            isConsoleOn = !isConsoleOn;
        }
        
        if (isConsoleOn)
        {
            ActivateConsole();
        }
        else if (!isConsoleOn)
        {
            DeactivateConsole();
        }

        if (isNoClip)
        {
            NoClip();
        }
        if (isNoClip == false)
        {
            Clip();
        }
    }

    public void ActivateConsole()
    {
        consoleScreen.SetActive(true);
        input.Select();
        firstPersonController.enabled = false;
        player.enabled = false;
    }

    public void DeactivateConsole()
    {
        consoleScreen.SetActive(false);
        firstPersonController.enabled = true;
        player.enabled = true;
    }

    public void ValueChangeCheck()
    {
        string text = input.text;

        if (text == "noclip")
        {
            isNoClip = true;
        }
        if (text == "clip")
        {
            isNoClip = false;
        }
    }

    void NoClip()
    {
        firstPersonController.enabled = false;
        flyingController.enabled = true;
        Debug.Log("No Clip On");
    }
    void Clip()
    {
        firstPersonController.enabled = true;
        flyingController.enabled = false;
    }
}
