using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Xsl;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// The intent here is to create something with functions encapsulated for both clarity and ease of running through a 
/// button. We also would tthen need to assign scene / entrance data as well before the load. 
/// </summary>
public class SceneExit_Modified : MonoBehaviour
{
    public string sceneToLoad;
    public string exitName;
    private GameObject loadCard;
    public float scenePauseTime = 2f;
    //test of key / lock through array functionality

    private VariableTracker varTracker;
    public bool isLocked;
    private string thisDoorLockName;


    private void Start()
    {
        loadCard = GameObject.Find("Loadscreen Group");
        thisDoorLockName = gameObject.name;
        varTracker = GameObject.Find("GameManager").GetComponent<VariableTracker>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && !isLocked)
        {
            SceneAndEntranceAssigner();
        }
        
        if (other.gameObject.CompareTag("Player") && isLocked)
        {
            if(varTracker != null && varTracker.HasKey(thisDoorLockName))
            {
                SceneAndEntranceAssigner();
            }
        }
        
    }

    public void SceneAndEntranceAssigner()
    {
        //the function of "NewScene" is actually to be read by the pause script
        //to spawn you back from pause into the right place
        PlayerPrefs.SetString("LastExitName", exitName);
        PlayerPrefs.SetString("NewScene", sceneToLoad);
        StartCoroutine(LoadCountdown());
    }
    public IEnumerator LoadCountdown()
    {
        SceneLoadCardFade receiver = loadCard.GetComponent<SceneLoadCardFade>();
        if (receiver != null)
        {
            StartCoroutine(receiver.FadeIn());
        }
        yield return new WaitForSeconds(scenePauseTime);
        SceneManager.LoadScene(sceneToLoad);
    }
}
