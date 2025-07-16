using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

	public GameObject center; //the thing orbited around
	public float speed; //the speed at thich the object orbits

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
	{
		OrbitAround ();
	}

	void OrbitAround()
	{
        //the term after "Vector3." can be altered to change axis, eg. forward, and speed set in 
        //inspector to negative to reverse dir.
        //transform.RotateAround (center.transform.position, Vector3.forward, speed * Time.deltaTime); 
        transform.RotateAround(center.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
