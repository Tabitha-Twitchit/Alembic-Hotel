using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FontChanger : MonoBehaviour
{
    public TMP_FontAsset newFont;
    private TMP_Text textDisplayer;
    private Image imageToCheck;
    // Start is called before the first frame update
    void Start()
    {
        textDisplayer = GetComponent<TMP_Text>();
        imageToCheck = GameObject.Find("Bee").GetComponent<Image>();
    }

 /*This is not ultimately the Method I would want to use. I would want
  * to check the variable (image.enabled) only on NPC click, but for proof of concept...*/
    void Update()
    {
        if(imageToCheck.enabled)
        {
            textDisplayer.font = newFont;
        }
    }
}
