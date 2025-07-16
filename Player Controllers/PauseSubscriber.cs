using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class PauseSubscriber : MonoBehaviour
{
    [SerializeField] private VariableTracker varTracker;
    private bool isPaused = false;
    private FirstPersonController charController;

    private void Awake()
    {
        if (varTracker != null)
        {
            varTracker.onPause += PauseController;
        }
    }

    void Start()
    {
        charController = GetComponent<FirstPersonController>();
    }

    
    private void OnDestroy()
    {
        varTracker.onPause -= PauseController;
    }

    void PauseController()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            charController.enabled = false;
        }
        else
        {
            charController.enabled = true;
        }
    }
}
