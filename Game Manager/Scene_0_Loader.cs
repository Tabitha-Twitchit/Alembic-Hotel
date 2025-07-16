using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_0_Loader : MonoBehaviour
{
 //using unity scene management (above) a specific collider set as a trigger will move the player to a specific scene number defined in the build settings
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene (0);
        }
    }
    
}
