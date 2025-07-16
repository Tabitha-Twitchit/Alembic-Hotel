using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroFader : MonoBehaviour
{
    private VariableTracker varTracker;
    public float transitionTime = 2f;
    private CanvasGroup groupToFade;
    // Start is called before the first frame update
    void Start()
    {
        varTracker = GameObject.FindGameObjectWithTag("GameManager").GetComponent<VariableTracker>();
        groupToFade = GetComponent<CanvasGroup>();
        if (varTracker != null)
        {
            varTracker.onIntroFade += DeactivateCanvas;
        }
    }

    void DeactivateCanvas()
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
     float counter = 0f;
          while (counter<transitionTime)
          {
              counter += Time.deltaTime;
              groupToFade.alpha = Mathf.Lerp(1f, 0f, counter / transitionTime);
              yield return null;
          }
    groupToFade.alpha = 0;
    groupToFade.interactable = false;
    groupToFade.blocksRaycasts = false;
    }


    void OnDestroy()
    {
        if (varTracker != null)
        {
            varTracker.onIntroFade -= DeactivateCanvas;
        }
    }
}
