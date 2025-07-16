using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAlbedoPulse : MonoBehaviour
{
    private Light light;
    public float pulseSpeed = 1f;
    public float maxLightIntensity = 3f;
    private Renderer rend;
    private Material mat;
    private Color baseColor;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        rend = GetComponent<Renderer>();
        mat = rend.material;
        baseColor = mat.color; // Save original color

    }

    // Update is called once per frame
    void Update()
    {
        // Create a ping-pong value between 0 and 1 over time
        float pulse = (Mathf.Sin(Time.time * pulseSpeed * Mathf.PI * 2f) + 1f) / 2f;

        // Set light intensity
        light.intensity = pulse * maxLightIntensity;

        // Scale color toward black
        Color fadedColor = baseColor * pulse;
        mat.color = fadedColor;
    }
}
