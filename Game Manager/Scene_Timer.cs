using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Timer : MonoBehaviour
{
    //sets the range in seconds
    public float maxTime = 5;
    public float minTime = 2;

    //current time
    private float time;

    //The time to load the level
    private float loadTime;

    void Start()
    {
        SetRandomTime();
        time = 0;
    }

    void FixedUpdate()
    {

        //Counts up
        time += Time.deltaTime;

        //Checks if its the right time to load the scene
        if (time >= loadTime)
        {
            //goes into the scene manger, finds the current scene, and pics the next one.  
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SetRandomTime();
            time = 0;
        }
    }


    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        loadTime = Random.Range(minTime, maxTime);
    }

}
