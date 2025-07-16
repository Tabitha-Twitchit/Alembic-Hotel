using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeactivateLight : MonoBehaviour
{
        private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);

            //GetComponent<MeshRenderer>().enabled = false;
            //GetComponent<ObjectText>().enabled = false;
            //GetComponent<Floater>().enabled = false;
            //GetComponent<Collider>().enabled = false;
            //GetComponent<Light>().enabled = false;
            //Destroying the game object is causing glitching as it seems the proc gen tool
            //can't then call it back, and the dungeon degenerates as you go
            //Destroy(this.gameObject);
            //So instead of above, we use:
            //this.gameObject.SetActive(false);
            //ultimately though we can deactivate components rather than the whole gameobject 
            //so the sound can keep playing, while staying on the same game obj 
        }
    }
}
