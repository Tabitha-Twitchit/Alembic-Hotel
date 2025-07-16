using UnityEngine;
using System.Collections.Generic;
using System.Collections;

//a "class" that is accessible to all scripts in this project is called Sound_on_Collision, and inherits "MonoBehavior"
//which is a base class that all C# scripts use to talk to the game engine.
public class Sound_on_Collision : MonoBehaviour
{
  
    //start is a "method" that is "called" when the script instance is enabled (like when the object is in your scene
    //and turned on)
    void Start ()   
	{
        //within this method we are accessing the component (on THIS object) called "AudioSource" (which you can see
        //in the inspector. We are then accessing a boolean variable already in that component called "playOnAwake" and
        //we are setting that variable to false. We are turning the sound OFF by default when the object is instantiated.
     
		GetComponent<AudioSource>().playOnAwake = false;
	}
    //Using the method OnTriggerEnter we are making it so that any collider that contacts our trigger collider (which
    //must be enabled on the collider component of our game object in the inspector) causes the component AudioSource 
    //to play 
    void OnTriggerEnter ()  
	{
		GetComponent<AudioSource>().Play() ;
	}
	
}

