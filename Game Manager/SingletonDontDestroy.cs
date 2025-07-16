using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonDontDestroy<T> : MonoBehaviour where T : MonoBehaviour
{
    //https://youtu.be/v9XBakreqCg

    public static T instance { get; private set; }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)FindObjectOfType(typeof(T));
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
}
