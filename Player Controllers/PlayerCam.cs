using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    //based on https://youtu.be/f473C43s8nE

    public float sensX;
    public float sensY;

    private GameObject orientation;

    float xRotation;
    float yRotation;


    // Start is called before the first frame update
    private void Start()
    {
        orientation = GameObject.Find("Orientation");
    }

    // Update is called once per frame
    void Update()
    {
        //gets mouse input and modifies with our sensitivity value
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        //keeps camera fromn rotating too much up/down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        //orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
