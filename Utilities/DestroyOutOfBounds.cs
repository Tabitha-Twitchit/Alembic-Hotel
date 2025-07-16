using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float zRange = 30.0f;

    // Update is called once per frame
    void Update()
    {
        //if this transform goes beyond the range on the Z axis it gets destroyed
        if (transform.position.z > zRange)
        {
            Destroy(gameObject);
        }

        //if this transform goes beyong the NEGATIVE range of the z axis it gets destroyed and a console message tells you you lost
        if (transform.position.z < -zRange)
        {
            Destroy(gameObject);
            Debug.Log("A critter got away!");
        }
    }
}
