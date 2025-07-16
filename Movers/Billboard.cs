using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    /// <summary>
    ///Causes both sprites and 3d objects to always face another object, main use case being the main camera.
    /// </summary>

    private GameObject cam;

    
    private void Start()
    {
        //assigns the target transform as the camera, can be set to whatever
        cam = GameObject.FindWithTag("MainCamera");
    }

    void LateUpdate()
    {
        transform.rotation = cam.transform.rotation;
        
        //This line is used only in the case of 3d objects as it is needed to face the front
        //of the object towards the camera. Remove for sprites or the sprite will flip.
        //transform.RotateAround(transform.position, transform.up, 180f);
    }
}
