using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnTrigger : MonoBehaviour
{
    public GameObject instantiated;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(instantiated, transform.position, Quaternion.identity);
        }
    }
}