using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived from this tutorial: https://youtu.be/HXaFLm3gQws?si=ws1X65SPHXHbDq3i
/// Exists because other simpler implimentatyions of Do Not Destroy only preserve 
/// a single object, or instance of the script. This doesn't work if you have a 
/// player with a separate camera, game manager, canvas, etc.
/// </summary>
public class DontDestroyMultiObject : MonoBehaviour
{
    public string objectID;

    private void Awake()
    {
        objectID = name + transform.position.ToString() + transform.eulerAngles.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < Object.FindObjectsOfType<DontDestroyMultiObject>().Length; i++) 
        {
            if (Object.FindObjectsOfType<DontDestroyMultiObject>()[i] !=this)
            {
                if (Object.FindObjectsOfType<DontDestroyMultiObject>()[i].objectID == objectID)
                {
                    Destroy(gameObject); 
                }
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
