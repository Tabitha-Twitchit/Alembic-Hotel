using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepUI : MonoBehaviour
{
    [SerializeField] private VariableTracker varTracker;
    //private Image symbol;
    //private Button confButton, declineButton;
    private CanvasGroup sleepUI;

    // Start is called before the first frame update
    void Start()
    {
        sleepUI = GetComponent<CanvasGroup>();
        if (varTracker != null)
        {
            varTracker.onBedUI += ShowSleepUI;
            varTracker.onObjectExit += HideSleepUI;
        }
    }

    public void ShowSleepUI()
    {
        sleepUI.alpha = 1;
        sleepUI.interactable = true;
        sleepUI.blocksRaycasts = true;
    }

    public void HideSleepUI()
    {
        Debug.Log("Got Here");
        sleepUI.alpha = 0;
        sleepUI.interactable = false;
        sleepUI.blocksRaycasts= false;
    }

    private void OnDestroy()
    {
        varTracker.onBedUI -= ShowSleepUI;
        varTracker.onObjectExit -= HideSleepUI;
    }

}
