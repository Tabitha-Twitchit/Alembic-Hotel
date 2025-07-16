using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reparenting : MonoBehaviour
{
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
            DontDestroyOnLoad(player);
        }

    }
}
