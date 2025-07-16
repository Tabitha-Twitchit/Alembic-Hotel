using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BibSubCats : MonoBehaviour
{
    /// <summary>
    /// A complimentary script to bibliography that handles lower levels in the hierarchy
    /// to allow less deep searching for turning sub cat canvases on and off. 
    /// </summary>
    /// <returns></returns>

    //Callback func for ShowSub, retrieves the name button that was just pressed
    //and passes it as a string into ShowSub
    public string BibCatNameGetter()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        if (clickedButton != null)
        {
            string bibCat = clickedButton.name;
            return bibCat;
        }
        else
        {
            return null;
        }
    }

    //A recursive callback to look through all descendants of a target transform
    GameObject FindDeepChild(Transform parent, string childName)
    {
        foreach (Transform child in parent)
        {
            if (child.name == childName)
            {
                return child.gameObject;
            }
            GameObject found = FindDeepChild(child, childName);
            if (found != null)
            {
                return found;
            }
        }
        return null;
    }

    //Called from each of the category buttons on the rootbib canvas
    public void ShowSub(string buttonName)
    {
        //FIRST goes through the child objects and hides each
        foreach (Transform child in transform)
        {
            CanvasGroup childCanvasGroup = child.GetComponent<CanvasGroup>();
            if (childCanvasGroup != null)
            {
                childCanvasGroup.alpha = 0;
                childCanvasGroup.interactable = false;
                childCanvasGroup.blocksRaycasts = false;
            }
        }

        //concats the button name with canvas to find obj
        string subCat = (BibCatNameGetter() + "canvas");
        //Passes the target subcat name into a recursive function to look thru all 
        //descendants
        GameObject subCatObj = FindDeepChild(transform, subCat);
        //targets the CanvasGroup of the found target object
        CanvasGroup subCatCanvasGroup = subCatObj.GetComponent<CanvasGroup>();
       
        //Adjusts values to show target
        subCatCanvasGroup.alpha = 1;
        subCatCanvasGroup.interactable = true;
        subCatCanvasGroup.blocksRaycasts = true;
        //Debug.Log("HONK " + subCat);
    }
}
