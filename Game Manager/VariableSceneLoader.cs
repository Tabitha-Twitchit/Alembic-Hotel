using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VariableSceneLoader : MonoBehaviour
{
    /// <summary>
    /// A scene loader that loads a scene of your choice depending on the string given in editor.
    /// Placed on a collider object, checks against player tag.
    /// </summary>
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            SceneManager.LoadScene(sceneName);
        }
    }
}
