using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CustomCommands : MonoBehaviour
{
   /*NOTE: All of these now live in a special region within the larger VariableTracker 
    * script. 
    * 
    * the script provides a one-stop-shop for all yarn commands. Where each method listed can be called
    * from YarnSpinner with the string in quotes.
   */
    
    public void Awake()
    {
        // dialogueRunner.AddCommandHandler("thedoors", DoorOpener);
     
    }
    
    /*
     public void DoorOpener()
     {
         GameObject doors = new GameObject();
         doors = GameObject.Find("Doors");
         Animator myAnimator = doors.GetComponent<Animator>();
         myAnimator.SetBool("opening", true);
     }
     */    
}

