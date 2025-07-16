using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


/// <summary>
/// This is a heavily modified version of the scene load system described in this tutorial:
/// https://youtu.be/U18j9t0XkaA?si=dhM1fFcEWR0dzWXe
/// It works in conjunction with a `SceneExit` script

/// It was modified to include functionality that ensures the `PositionPlayer`
/// function is called only after the scene is loaded. It also adds functionality 
/// designed to work with the Unity Standard Assets character controller that briefly
/// deactivates the Unity SA FP Controller because it overrides the `PositionPlayer` 
/// function.
///  
/// </summary>
public class SceneEntrance : MonoBehaviour
{
    public string lastExitName;
    private GameObject player;
    private VariableTracker varTracker;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Once the scene is loaded, call the following co-routine
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("SceneEntrance expected exit: " + lastExitName);
        //Debug.Log("SceneEntrance received LastExitName: " + PlayerPrefs.GetString("LastExitName"));
        //Debug.Log(lastExitName.Length);
        //Debug.Log(PlayerPrefs.GetString("LastExitName").Length);
        StartCoroutine(PositionPlayer());
    }

    IEnumerator PositionPlayer()
    {

        // Wait until the player is available (max 3 seconds)
        //Assigns the player through the loop
        float timeout = 3f;
        while ((player = GameObject.FindGameObjectWithTag("Player")) == null && timeout > 0f)
        {
            timeout -= Time.deltaTime;
            yield return null;
        }
        
        //Checks and warnings that components are present / not.
        //Debug.Log("Player GameObject found: " + player.name);
        //foreach (var comp in player.GetComponents<Component>())
        //{
        //    Debug.Log("Component on Player:  " + comp.GetType());
        //}
        if (player == null)
        {
            Debug.LogError("Player object not found after timeout.");
            yield break;
        }
        // Grab reference to VariableTracker
        varTracker = GameObject.Find("GameManager")?.GetComponent<VariableTracker>();
        if (varTracker == null)
        {
            Debug.LogWarning("VariableTracker not found. Proceeding without room check.");
        }

        // Main conditional gate for positioning
        // if the player is there and the PLAYER exit matches the ENTRANCE'S exit name
        // (i.e. where it's coming FROM) do...
        if (PlayerPrefs.GetString("LastExitName") == lastExitName || (varTracker != null && varTracker.isInRoom))
        {
            // Disable character control to avoid LateUpdate interference
            var fpc = player.GetComponent<FirstPersonController>();
            if (fpc == null)
            {
                Debug.LogError("FirstPersonController component missing on Player.");
                yield break;
            }

            // here we need to briefly suspend character controls because we are using
            // the Unity Standard Assets Char Controller that moves on LateUpdate and 
            // overrides our placement function immediately below.
            fpc.enabled = false;
            player.GetComponent<CharacterController>()?.Move(Vector3.zero);

            // Move and rotate the player
            player.transform.position = transform.position;
            player.transform.rotation = transform.rotation;

            // Wait a moment before reactivating controller
            yield return new WaitForSeconds(0.5f);
            fpc.enabled = true;
        }
    }
        //For Debugging: Checks for duplicate players
        //if (GameObject.FindGameObjectsWithTag("Player").Length > 1)
        //    {
        //        Debug.LogError("Multiple player objects detected!");
        //    }
        //else
        //    {
        //        Debug.Log("1 or fewer players here");
        //    }
    //}
//}
}


