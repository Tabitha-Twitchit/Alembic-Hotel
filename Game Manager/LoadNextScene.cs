using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
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

        //Check if its the right time to load the scene
        if (time >= loadTime)
        {
            //int index = Random.Range(0, 4);
            //you used this before but it was only for loaded scenes: SceneManager.sceneCount);
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
