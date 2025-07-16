using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying_Player_movement : MonoBehaviour
{
    
    public float speed = 5;
 
    // Update is called once per frame
    void Update()
    {
        //                 new vector3(1, 0, 0) * 5 * real time
        float xInput = Input.GetAxis("X Axis");
        float zInput = Input.GetAxis("Z Axis");
        float yInput = Input.GetAxis("Y Axis");
        transform.Translate(new Vector3(xInput, yInput, zInput) * speed * Time.deltaTime);
    }
}
