using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDText : MonoBehaviour
{
    public static HUDText instance;
    //For regular text use this and "using UnityEngine.UI;" above
    //public Text text;
    //for Text Mesh Pro use below and "using TMPro;"
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
