using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Up : MonoBehaviour
{
    public Material poweredUp;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "powerUp")
        {
            rend.sharedMaterial = poweredUp;
            Destroy(other.gameObject);
        }
    }
}
