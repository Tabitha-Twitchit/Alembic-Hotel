using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBoolFlipper : MonoBehaviour
{
    private VariableTracker varTracker;
    // Start is called before the first frame update
    void Start()
    {
        varTracker = GameObject.Find("GameManager").GetComponent<VariableTracker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        varTracker.isInRoom = !varTracker.isInRoom;
    }

}
