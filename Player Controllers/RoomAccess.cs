using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RoomAccess : MonoBehaviour
{
    [Header("Keybinds")]
    public KeyCode roomKey = KeyCode.P;
    
    //Stuff used for checking variables elsewhere
    private VariableTracker varTracker;
    private bool isInRoom = false;
    //private Pickup_w_counter packetCounter;
    //private GameObject consoleScreen;
    
    //private bool isConsoleOn = false;

    void Start()
    {
        varTracker = GameObject.Find("GameManager").GetComponent<VariableTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKey(roomKey) && varTracker.isRoomKeyed)
        {
            GoToRoom();        
        }
        */
    }

    void GoToRoom()
    {
        isInRoom = !isInRoom;
        if (isInRoom)
        {
            SceneManager.LoadScene("Room");
        }
        else
        {
            //Need some way of tracking prev scene akin to the entrance/exit pair to put the player back where they were

            SceneManager.LoadScene("Atrium");
        }
    }
}
