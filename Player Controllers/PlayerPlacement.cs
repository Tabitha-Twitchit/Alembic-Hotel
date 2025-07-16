using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlacement : MonoBehaviour
{
    /// <summary>
    /// Designed to be placed at a location in each level where you want the player to begin when using a 
    /// player with DoNotDestroy on it.The script will place the player on the transform of the game object
    /// bearing this script and point the camera at a second object to ensure clean edits, or that the character 
    /// isn't looking back through the door which they just entered, etc.
    /// </summary>

    private GameObject player;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = this.transform.position;
    }
}