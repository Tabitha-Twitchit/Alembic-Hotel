using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    /*the different cursor textures to bring in, and a distance at which the change should happen (this prevents
     * objects from a great distance appearing to be interactable. Note this script could theoretically be 
     * incorporated into the main player ray casting script but isn't for no real reason other than ease of having
     * and seeing small discreet scripts in my workflow. It's range here should match it's range there to 
     * avoid confusion. 
     */
    public Texture2D defaultCursor, clickableCursor;
    public float range;

    //keeps cursor visible and locked into FOV
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * range);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range) && hit.collider.gameObject.CompareTag("NPC"))
        {
            Cursor.SetCursor(clickableCursor, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}
