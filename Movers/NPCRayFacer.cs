using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRayFacer : MonoBehaviour
{
    //the thing you want this game object to face
    private Transform target;

  
    /*this is a seemingly hacky way to ensure that we find the exact right object to face.
     * The problem with not including this was that after reloading the scene, the script
     * would not re-locate the player (because it was loading a dif instance or soommmmething*/
    void Start()
    {
        target = FindObjectOfType<PlayerRay>().transform;
    }

    /*So, right now this is being triggered by SendMessage in the Player Ray script, which 
     * is definitely sub-optimal. May overhaul later to properly trigger the function remotely*/
    void HitByRay()
    {
        //so this is a little tricky--the transform looks only at the target's x and z position
        //and its OWN Y position. This essentially locks it from leaning back and looking up at
        //the player in a weird way.
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        //Debug.Log("I was hit by a ray!");

    }
}
