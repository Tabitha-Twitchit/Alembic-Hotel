using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// This script goes on the object responsible for initiating summoning the elevator
/// In the current game (IG2) that is the YarnInteractable NPC. When clicked on it
/// sorts through all the nearest elevator stop objects (invisible transforms tagged
/// "ElevatorStop" that tell the Yarnovator script where to move to) and selects the
/// nearest one to THIS gameobject so that they will be different on every level, 
/// assuming every level has an NPC such as this. It then passes this transform into
/// a couritine on the yarnovator/elevator object itself.
/// </summary>

public class ElevatorCall : MonoBehaviour
{
    public Yarnovator elevator;
    private Transform thisFloorStop;

    //private void OnMouseDown()
    //{
    //    thisFloorStop = FindNearest("ElevatorStop");
    //    elevator.StartCoroutine(elevator.CallElevator(thisFloorStop));
    //    Debug.Log("made it into OnMouseDown");
    //}

    // Copying an alternate version to work with the ray rather than onMouseDown
    // the call is made from YarnInteractable
    public void sendElevator()
    {
        thisFloorStop = FindNearest("ElevatorStop");
        elevator.StartCoroutine(elevator.CallElevator(thisFloorStop));
    }

    Transform FindNearest(string tag)
    {
        GameObject[] elevStops = GameObject.FindGameObjectsWithTag(tag);
        if (elevStops.Length == 0) return null;
        return elevStops.OrderBy(t => (t.transform.position - transform.position).sqrMagnitude).First().transform;
    }
}