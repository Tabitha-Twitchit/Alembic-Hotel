using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDoNotDestroy : MonoBehaviour
{
    public static StaticDoNotDestroy Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;    
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
