using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This is a modified version of the scene load system described in this tutorial:
/// https://youtu.be/U18j9t0XkaA?si=dhM1fFcEWR0dzWXe
/// It was modified to include a coroutine with a delay to ensure that the player
/// positioning only happens once the player is loaded into the scene. Otherwise,
/// the SceneEntrance can load and call Start before the player, which then causes
/// the player to load in at their previous transform.position. The scene management
/// amd event subscription stuff commented out were suggested by an AI, but are 
/// superfluous witth the addition of the coroutine. Leaving them in for options tho
/// </summary>
public class SceneEntranceRoom : MonoBehaviour
{
    //public string lastExitName;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        player.transform.position = transform.position;
        player.transform.rotation = transform.rotation;
    }


}
