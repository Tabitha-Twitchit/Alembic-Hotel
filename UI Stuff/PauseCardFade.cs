using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCardFade : MonoBehaviour
{
    [SerializeField] private VariableTracker varTracker;
    public float transitionTime = 0.5f;
    private CanvasGroup pauseScreen;
    public bool isPaused = false;
    
    private void Awake()
    {
        if (varTracker != null)
        {
            varTracker.onPause += PauseFlip;
        }
    }
    private void Start()
    {
        pauseScreen = GetComponent<CanvasGroup>();
    }
    private void OnDestroy()
    {
        if(varTracker != null)
        {
        varTracker.onPause -= PauseFlip;
        }
    }
    void PauseFlip()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            StartCoroutine(FadeIn());
        }
        else
        {
            //NOTE An alt method of pausing is to stop time. This caused glitches with 
            //rapid keypresses so now pausing is done by disabling the char controller
            //through a "PauseSubscriber" script
            //Time.timeScale = 1;
            StartCoroutine(FadeOut());
        }
    }
    
    public IEnumerator FadeIn()
    {
        float counter = 0f;
        while (counter < transitionTime)
        {
            counter += Time.deltaTime;
            pauseScreen.alpha = Mathf.Lerp(0f, 1f, counter / transitionTime);
            yield return null;
        }
        pauseScreen.alpha = 1f;
        //NOTE See above not about pausing and time. 
        //Time adjustment goes here after fade, or else it won't fade.
        //Time.timeScale = 0;
    }

    public IEnumerator FadeOut()
    {
        float counter = 0f;
        while (counter < transitionTime)
        {
            counter += Time.deltaTime;
            pauseScreen.alpha = Mathf.Lerp(1f, 0f, counter / transitionTime);
            yield return null;
        }
        pauseScreen.alpha = 0f;
    }
}
