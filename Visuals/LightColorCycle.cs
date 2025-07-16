using UnityEngine;

public class LightColorCycle : MonoBehaviour
{
    public float speed = 1.0f;
    private Light lightComponent;
    private float time;

    void Start()
    {
        lightComponent = GetComponent<Light>();
    }

    void Update()
    {
        time += Time.deltaTime * speed;
        if (time > 1.0f)
        {
            time -= 1.0f;
        }

        lightComponent.color = Color.HSVToRGB(time, 1.0f, 1.0f);
    }
}
