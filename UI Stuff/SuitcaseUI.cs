using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuitcaseUI : MonoBehaviour
{
    [SerializeField] private VariableTracker varTracker;
    private CanvasGroup suitcaseUI;

    // Start is called before the first frame update
    void Start()
    {
        suitcaseUI = GetComponent<CanvasGroup>();
        if(varTracker != null)
        {
            varTracker.onSuitcaseUI += ShowSuitcaseUI;
            varTracker.onObjectExit += HideSuitcaseUI;
        }
    }
    private void OnDestroy()
    {
        /*NOTE: Becayse this subscriber is in a scene that will be destroyed and is not
         * a DDOL object, it must check if the varTracker is null or it will throw an 
         * null ref exceptio error*/
        if (varTracker != null)
        {
            varTracker.onSuitcaseUI -= ShowSuitcaseUI;
            varTracker.onObjectExit -= HideSuitcaseUI;
        }
        
    }

    public void ShowSuitcaseUI()
    {
        suitcaseUI.alpha = 1;
        suitcaseUI.interactable = true;
        suitcaseUI.blocksRaycasts = true;
    }

    public void HideSuitcaseUI()
    {
        suitcaseUI.alpha = 0;
        suitcaseUI.interactable = false;
        suitcaseUI.blocksRaycasts = false;
    }
}
