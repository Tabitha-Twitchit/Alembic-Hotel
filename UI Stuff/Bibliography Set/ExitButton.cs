using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    private VariableTracker varTracker;
    void Start()
    {
        varTracker = GameObject.Find("GameManager").GetComponent<VariableTracker>();
    }

    public void ExitCall()
    {
        varTracker.ObjectUIExit();
    }
}
