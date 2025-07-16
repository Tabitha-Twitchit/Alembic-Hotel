using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private GameObject camPos;
    //private Transform cameraPosition;

    private void Start()
    {
        camPos = GameObject.Find("CameraPos");
        //cameraPosition = transform.find("CameraPos");
    }

    //a script that moves your camera along with a given transform without childing camera to that transform.
    void Update()
    {
        transform.position = camPos.transform.position;
        //transform.position = cameraPosition.position;
    }
}
