using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    //sets the floors and rate of speed the elevator travels
    public Transform origin, target;
    public float speed;
    
    private bool goingDown = false;
    
    /*When this method is called (from the the ElevatorPanel script) it 
     * toggles the boolean for whether the elevator is going down or not
     */
    public void CallElevator()
    {
        goingDown = !goingDown;
    }

    private void FixedUpdate()
    {
        if (goingDown == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (goingDown == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, origin.position, speed * Time.deltaTime);
        }
    }
    
    //if another collider object tagged player enters the trigger its parent becomes this object.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    //if another collider object tagged player leaves the trigger its parent is no longer this object.
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
