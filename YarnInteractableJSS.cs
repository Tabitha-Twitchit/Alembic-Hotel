using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;


public class YarnInteractableJSS : MonoBehaviour {

    // internal properties exposed to editor
    [SerializeField] private string conversationStartNode;
    [SerializeField] private string incomprehnsibleStartNode;
    private VariableTracker varTracker;
    private GameObject player;
    private Behaviour firstPersonController;
    private CharacterController characterController;
    // internal properties not exposed to editor
    private DialogueRunner dialogueRunner;
    private bool interactable = true;
    private bool isCurrentConversation = false;
    
    public void Start() {

        varTracker = GameObject.Find("GameManager").GetComponent<VariableTracker>();
        /*
        if(varTracker != null)
        {
            varTracker.onJSSInteractWBee += BeeConvo;
        }
        */

        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);

        //TABITHA you added this to get the specific player script(s) to activate and deactivate and store at start.
        //note that the gameobject.find method is what allows you to not destroy the players/cams from prev scenes but
        //still reference them.
        player = GameObject.Find("Player");
        firstPersonController = player.GetComponent<FirstPersonController>();
        characterController = player.GetComponent<CharacterController>();
        //firstPersonController = GameObject.Find("Player").GetComponent<FirstPersonController>();
        //characterController = GameObject.Find("Player").GetComponent<CharacterController>();
    }

    public void OnMouseDown() {
        if (interactable && !dialogueRunner.IsDialogueRunning) {
            StartConversation();
        }
    }

    private void StartConversation() {
        if(varTracker.beeModule)
        {
            Debug.Log($"Started conversation with {name}.");
            isCurrentConversation = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            firstPersonController.enabled = false;
            characterController.enabled = false;
            dialogueRunner.StartDialogue(conversationStartNode);
        }
        else
        {
            Debug.Log($"Started conversation with {name}.");
            Debug.Log("event received correct logic being followd");
            isCurrentConversation = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            firstPersonController.enabled = false;
            characterController.enabled = false;
            dialogueRunner.StartDialogue(incomprehnsibleStartNode);
        }
        
    }
    /*
    private void BeeConvo()
    {
        isComprehensible = true;
        Debug.Log("event received" + isComprehensible);

    }
    */

    //Tabi you made this public to try and access it from the end conversation UI button onClick
    public void EndConversation() {
        if (isCurrentConversation) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            firstPersonController.enabled = true;
            characterController.enabled = true;
            isCurrentConversation = false;
            Debug.Log($"Ended conversation with {name}.");
        }
    }
    /*Including this command throws an error at Awake. I believe this is because this
     * script is a version of the normal YarnInteractable.cs script that all NPCs use,
     * and Yarn Commands must essentially be unique to a class. This command is not
     * called in the dialogue itself, or used in my game manager and seems internal 
     * to a YarnSpinner dialoguerunner or other script that can make a character non 
     * interactive based on some other condition. The game seems to run as expected 
     * without it, but leaving it for posterity.
 
    [YarnCommand("disable")]
    public void DisableConversation() {
        interactable = false;
    }
*/    
}