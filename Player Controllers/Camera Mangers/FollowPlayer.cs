using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0,5,-7);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //the transform position of THIS gameobject becomes tied to that of the player, with an added offset as a vector3
        transform.position = player.transform.position + offset;
    }
}
