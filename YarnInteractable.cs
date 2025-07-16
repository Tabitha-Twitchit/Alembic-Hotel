using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;


public class YarnInteractable : MonoBehaviour {
    // internal properties exposed to editor
    [SerializeField] private string conversationStartNode;
    private GameObject player;
    private Behaviour firstPersonController;
    private CharacterController characterController;
    // internal properties not exposed to editor
    private DialogueRunner dialogueRunner;
    private bool interactable = true;
    private bool isCurrentConversation = false;
    private VariableTracker varTracker;

    private ElevatorCall elevatorCall;
    
    public void Start() {
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
        varTracker = GameObject.Find("GameManager").GetComponent<VariableTracker>();

        elevatorCall = GetComponent<ElevatorCall>();
    }

    //TABI This is the original method for getting interaction started, you changed this to a ray that
    // calls the convoStarter function on the hit object instead, because the "mouse" used in onMouseDown
    // is centered and your window is not. 

    //public void OnMouseDown() 
    //{
    //    if (interactable && !dialogueRunner.IsDialogueRunning) 
    //    {
    //        StartConversation();
    //    }
    //}
    public void convoStarter()
    {
        if (interactable && !dialogueRunner.IsDialogueRunning)
        {
            StartConversation();
        }

        if (elevatorCall != null)
        {
            elevatorCall.sendElevator();
        }
    }

    private void StartConversation() 
    {
        Debug.Log($"Started conversation with {name}.");
        Debug.Log("event received correct logic being followd");
        isCurrentConversation = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        firstPersonController.enabled = false;
        characterController.enabled = false;
        dialogueRunner.StartDialogue(conversationStartNode);
        varTracker.isInUI = true;
    }

    //Tabi you made this public to try and access it from the end conversation UI button onClick
    public void EndConversation() {
        if (isCurrentConversation) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            firstPersonController.enabled = true;
            characterController.enabled = true;
            isCurrentConversation = false;
            Debug.Log($"Ended conversation with {name}.");
            varTracker.isInUI = false;

        }
    }
    
    [YarnCommand("disable")]
    public void DisableConversation() {
        interactable = false;
    }

    //private void Update()
    //{
    //    Debug.Log("is interactable?" + interactable);
    //}
}