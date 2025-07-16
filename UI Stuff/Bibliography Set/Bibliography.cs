using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class bibliography : MonoBehaviour
{
    //parent canvas group
    private CanvasGroup bibCanvas;
    [SerializeField] private VariableTracker varTracker;

    /// <summary>
    /// Part of a trio of scripts (along with BibSubCats and CitationLink) that comprise 
    /// the whole bibliography system. This script controls the present of the root menu 
    /// with various categories
    /// 
    /// TABI  NOTE THE EXIT BUTTON MAY HAVE TO WORK DIFFERENTLY IDK IF IT WILL FIND THE
    /// REF to VAR TRACKER you will need a custom button script it self refs that
    /// finds the DDOL varTracker on start and then executes its action invocation
    /// to exit object UI
    /// </summary>

    void Start()
    {
        varTracker = GameObject.Find("GameManager").GetComponent<VariableTracker>();
        if (varTracker != null)
        {
            varTracker.onBiblioUI += ShowBibRoot;
            varTracker.onObjectExit += HideBib;
        }
        else
        {
            Debug.LogWarning("Var tracker ref is null in biblio");
        }

        bibCanvas = GetComponentInChildren<CanvasGroup>();
        
        //hides bib from go, so you can work on it in editor
        HideBib();
    }
    private void OnDestroy()
    {
        if (varTracker != null)
        {
            varTracker.onBiblioUI -= ShowBibRoot;
            varTracker.onObjectExit -= HideBib;
        }
    }
    public void ShowBibRoot()
    {
        bibCanvas.alpha = 1;
        bibCanvas.interactable = true;
        bibCanvas.blocksRaycasts = true;
    }
    public void HideBib()
    {
        bibCanvas.alpha = 0;
        bibCanvas.interactable = false;
        bibCanvas.blocksRaycasts = false;
    }
}
