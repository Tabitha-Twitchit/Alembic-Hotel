using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomCollector : MonoBehaviour
{
    public AudioSource shroomsound;

    void Start()
    {
        shroomsound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.gameObject.CompareTag("shroom"))
            {
                shroomsound.Play();
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
