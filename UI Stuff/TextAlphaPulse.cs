using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAlphaPulse : MonoBehaviour
{
    public float minAlpha = 0;
    public float maxAlpha = 1;
    public float speed;
    private TMP_Text pulseText;
    // Start is called before the first frame update
    void Start()
    {
        pulseText = GetComponent<TMP_Text>();
        StartCoroutine(PulseAlpha());
    }

    IEnumerator PulseAlpha()
    {
        while (true) // Loop indefinitely for continuous pulsing
        {
            // Calculate the current alpha value using a sine wave
            float alpha = Mathf.Lerp(minAlpha, maxAlpha, (Mathf.Sin(Time.time * speed * 2 * Mathf.PI) + 1) / 2);

            // Set the text color with the new alpha
            Color currentColor = pulseText.color;
            currentColor.a = alpha;
            pulseText.color = currentColor;

            yield return null; // Wait for the next frame
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
