using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    //if there is a collision with this object
    void OnCollisionEnter(Collision other)
    {
        //by an object tagged player
        if (other.gameObject.CompareTag("Player"))
        {
            //destroy this object in X seconds
            Destroy(gameObject, 1);
        }
    }
}
