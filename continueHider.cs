using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The function of this is to get the continue button out of the way
/// when QR codes are up because ending dialogue through continuing to 
/// conclusion keeps the images up. This is V hacky and the better way 
/// to do this would be to see HOW yarn ends dialogue thru cont and tap 
/// into that call
/// </summary>
public class continueHider : MonoBehaviour
{
    [SerializeField] private VariableTracker varTracker;

    void Start()
    {
        varTracker = GameObject.Find("GameManager").GetComponent<VariableTracker>();
        if (varTracker != null)
        {
            //varTracker.onQRShow += hideContButton;
            varTracker.onObjectExit += showContButton;
        }
        else
        {
            Debug.LogWarning("Var tracker ref is null in biblio");
        }
    }

    private void OnDestroy()
    {
        if (varTracker != null)
        {
            //varTracker.onQRShow -= hideContButton;
            varTracker.onObjectExit += showContButton;
        }
    }

    public void hideContButton(string passageTitle) 
    {
        GetComponent<Button>().enabled = false; // remove functionality
        GetComponent<Image>().enabled = false; // remove rendering
    }

    public void showContButton()
    {
        GetComponent<Button>().enabled = true; // remove functionality
        GetComponent<Image>().enabled = true; // remove rendering
    }
}
