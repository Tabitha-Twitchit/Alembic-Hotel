using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This whole bullshit is because I can't figure out how either Yarn DialogueRunner or Lineview
/// organically ends dialogue and impliment it in an exit button. So now I have the exit button call
/// all this.
/// </summary>
public class UIDisabler : MonoBehaviour
{
    private Image backGround;
    private TextMeshProUGUI charName;
    private Image divider;
    private TextMeshProUGUI textItself;
    private Button contButton;
    private Button exitButton;
    private TextMeshProUGUI contText;
    private TextMeshProUGUI exitText;

    private void Start()
    {
        backGround = GameObject.Find("Background").GetComponent<Image>();
        charName = GameObject.Find("Character Name").GetComponent<TextMeshProUGUI>();
        divider = GameObject.Find("Divider").GetComponent<Image>();
        textItself = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        contButton = GameObject.Find("Continue Button").GetComponent<Button>();
        exitButton = GameObject.Find("Exit Button").GetComponent<Button>();
        contText = GameObject.Find("Cont Button Text").GetComponent<TextMeshProUGUI>();
        exitText = GameObject.Find("Exit Button Text").GetComponent<TextMeshProUGUI>();
    }

    public void DisableUI()
    {
        backGround.enabled = false;
        charName.enabled = false;   
        divider.enabled = false;    
        textItself.enabled = false;
        contButton.image.enabled = false;
        exitButton.image.enabled = false;
        contText.enabled = false;
        exitText.enabled = false;
    }

}
