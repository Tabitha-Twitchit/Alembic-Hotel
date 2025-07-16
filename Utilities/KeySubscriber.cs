using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class KeySubscriber : MonoBehaviour
{
    [SerializeField] private VariableTracker varTracker;
    private Image img;

    void Start()
    {
        img = GetComponent<Image>();
    }

    private void Awake()
    {
        if (varTracker != null)
        {
            varTracker.onGiveKey += OnDisplayKey;
        }
    }

    private void OnDisplayKey()
    {
        img.enabled = true;
    }

    private void OnDestroy()
    {
        if( varTracker != null)
        {
        varTracker.onGiveKey -= OnDisplayKey;
        }
    }
}
