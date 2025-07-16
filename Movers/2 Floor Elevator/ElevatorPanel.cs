using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    /*The first variable is reserved for accessing the elevator script on 
     * our elevator object.
     */
    private Elevator elevator;

    private bool elevatorCalled = false;
    private bool canCallElevator = false;

    public MeshRenderer callButton;


    /*on start looks for our specific elevator object and gets the elevator script from inside it.
     * throws an error if it can't find it*/
    void Start()
    {
        elevator = GameObject.Find("Elevator").GetComponent<Elevator>();    

        if (elevator == null)
        {
            Debug.LogError("Elevator is Null!");
        }
    }

    //Every frame look to run the Elevator Control function
    void Update()
    {
        ElevatorControl();
    }

    //If within the collider's trigger area and tagged player, the boolean
    //of whether you can call the elevator is set to true
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canCallElevator = true;
        }
    }

    //If the object tagged player leaves the ability to call the elevator 
    //is switched to false. Both of these are simply used as criterea in
    //the Elevator Control method below.
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canCallElevator = false;
        }
    }

    
    /*When this method is run it checks the criteria (key press and trigger
     * boolean. I believe elevatorCalled is just used to determine the
     * button material. But if the criteria are met CallElevator is run
     * from the other elevator script
     */
    private void ElevatorControl()
    {
        if (Input.GetKeyDown(KeyCode.E) && canCallElevator)
        {
            if (elevatorCalled == true)
            {
                callButton.material.color = Color.red;
                elevatorCalled = false;
            }

            else
            {
                callButton.material.color = Color.green;
                elevatorCalled = true;
            }
            elevator.CallElevator();
        }
    }
}
