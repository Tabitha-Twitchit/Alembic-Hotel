using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReParenter : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        //Debug.Log("found the player");
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            //other.transform.parent = transform.parent;
            other.transform.parent = this.transform;
            Debug.Log("Reassigned");
        }
    }
    //unparents the player when out of the trigger, and weirdly, you need to re DDOL the player because
    //unparenting it removes it from the DDOL scene...shrug.
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
            DontDestroyOnLoad(player);
        }
    }
}
