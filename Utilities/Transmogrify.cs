using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmogrify : MonoBehaviour
{//public GameObjects allow models to be specified in the inspector 
    public GameObject secondaryObject;
    public GameObject specialEffect;
    public GameObject tertiaryObject; 

    // Update is called once per frame
    void Update()
    {//if spacebar is pressed down
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //A special effect is instantiated from the public GameObject
            //The secondary game object is instantiated, 
            Instantiate(specialEffect, transform.position, Quaternion.identity);
            GameObject secondaryObjectObj = Instantiate(secondaryObject, transform.position, Quaternion.identity);
            Rigidbody[] allRigidBodies = secondaryObjectObj.GetComponentsInChildren<Rigidbody>();
            //and if it has rigid bodies forces are applied
            if (allRigidBodies.Length > 0)
            {
                foreach (var body in allRigidBodies)
                {
                    //(newtons of force, location, radius)
                    body.AddExplosionForce(500, transform.position, 50);
                }
            }
            //the game object this script is on is destroyed
            Destroy(this.gameObject);
            //and a third game object is revealed
            Instantiate(tertiaryObject, transform.position, Quaternion.identity);
        }
    }
}