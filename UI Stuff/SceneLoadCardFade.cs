using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadCardFade : MonoBehaviour
{

    [SerializeField] private VariableTracker varTracker;
    public float transitionTime = 2f;
    private CanvasGroup loadScreen;
    // Start is called before the first frame update
    private void Awake()
    {
        loadScreen = GetComponent<CanvasGroup>();

        if (varTracker != null)
        {
            varTracker.onLoad += BeginFade;
            varTracker.onForceUIFade += FadeOutOnly;
        }
    }

    void Start()
    {
        //TABI you moved to awake to accomodate the force fade call
        //action from varTracker on scene load because it wasn't always self fading
        //loadScreen = GetComponent<CanvasGroup>();
    }

    private void OnDestroy()
    {
        if (varTracker != null)
        {
        varTracker.onLoad -= BeginFade;
        varTracker.onForceUIFade -= FadeOutOnly;
        }
    }
    void BeginFade()
    {
        StartCoroutine(FadeIn());
    }

    void FadeOutOnly()
    {
        //Debug.Log("We in FadeOutOnly?");
        if(loadScreen.alpha > 0)
        {
        StartCoroutine(FadeOut());
        }
    }

    public IEnumerator FadeIn()
    {
        float counter = 0f;
        while (counter < transitionTime)
        {
            counter += Time.deltaTime;
            loadScreen.alpha = Mathf.Lerp(0f, 1f, counter / transitionTime);
            yield return null;
        }
        loadScreen.alpha = 1f;
        StartCoroutine(FadeOut());
    }
   
      public IEnumerator FadeOut()
      {
          float counter = 0f;
          while (counter < transitionTime)
          {
              counter += Time.deltaTime;
              loadScreen.alpha = Mathf.Lerp(1f, 0f, counter / transitionTime);
              yield return null;
          }
          loadScreen.alpha = 0f;
      }
}
