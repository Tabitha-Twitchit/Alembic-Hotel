using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Recursive_Door : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player")
        {
			//The scene number to load (in File->Build Settings) Q? How could this door be made non recursive?
			SceneManager.LoadScene (0);	
		}
	}
}
