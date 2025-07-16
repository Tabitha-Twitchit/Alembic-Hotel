using UnityEngine;

public class FadeMaterial : MonoBehaviour
{
    public float duration = 1.0f; // Duration for one complete fade cycle (alpha 0 -> 1 -> 0)
    private Material material;
    private float direction = 1.0f;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            //could also write
            //material = renderer.material;
            //but this version is to target a specific material on an object with an array of materials
            material = renderer.materials[1];
        }
    }

    void Update()
    {
        if (material != null)
        {
            Color color = material.color;
            float alpha = color.a + (direction * Time.deltaTime / duration);

            if (alpha >= 1.0f)
            {
                alpha = 1.0f;
                direction = -1.0f;
            }
            else if (alpha <= 0.0f)
            {
                alpha = 0.0f;
                direction = 1.0f;
            }

            color.a = alpha;
            material.color = color;
        }
    }
}
