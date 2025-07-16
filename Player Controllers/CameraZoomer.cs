using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    public float zoomSpeed = 4f;
    public float minZoom = 2f;
    public float maxZoom = 10f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");

        cam.orthographicSize -= scrollData * zoomSpeed;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
    }
}