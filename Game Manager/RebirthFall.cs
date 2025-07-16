using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RebirthFall : MonoBehaviour
{
    //a falling script that will restart you in the current scene

    void Update()
    {
        if (gameObject.transform.position.y <= -30)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}