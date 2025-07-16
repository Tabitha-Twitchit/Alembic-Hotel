using TMPro;
using UnityEngine;
using Yarn.Unity;

public class LineViewExtension : DialogueViewBase
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    //[SerializeField] private TextMeshProUGUI characterNameText;

    public void ClearText()
    {
        if (dialogueText != null)
        {
            dialogueText.text = "";
            dialogueText.maxVisibleCharacters = 0;
        }

        //if (characterNameText != null)
        //{
        //    characterNameText.text = "";
        //}
    }
}
