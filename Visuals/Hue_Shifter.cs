using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hue_Shifter : MonoBehaviour
{
    public float Speed = 1;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.SetColor("_Color", HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * Speed, 1), 1, 1)));
    }
}
