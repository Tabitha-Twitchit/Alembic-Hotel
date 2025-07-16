using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerControl : MonoBehaviour
{
    private bool isFlickering = false;
    private float timeDelay;
    public float lowestDelay;
    public float highestDelay;
    private Renderer rend;
    private Material mat;
    private Color baseEmissionColor = Color.white;
    private Color noEmissionColor = Color.black;

    private Light lightSource;

    void Start()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;
        mat.EnableKeyword("_EMISSION");
        lightSource = GetComponent<Light>();

        baseEmissionColor = mat.GetColor("_EmissionColor");

    }


    void Update()
    {
        if (!isFlickering)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;

        lightSource.enabled = false;
        mat.SetColor("_EmissionColor", noEmissionColor);

        timeDelay = Random.Range(lowestDelay, highestDelay);
        yield return new WaitForSeconds(timeDelay);

        lightSource.enabled = true;
        mat.SetColor("_EmissionColor", baseEmissionColor);

        timeDelay = Random.Range(lowestDelay, highestDelay);
        yield return new WaitForSeconds(timeDelay);

        isFlickering = false;
    }
}
