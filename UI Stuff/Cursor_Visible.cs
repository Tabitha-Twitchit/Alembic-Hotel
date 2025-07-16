using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Visible : MonoBehaviour
{
    public Texture2D defaultCursor, clickableCursor;
    public static Cursor_Visible instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    // forces the cursor to be seen and keeps in the FOV
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    
    //pairs with Clickable_Object script to change the cursor when an object is hovered over. That sister script goes on the
    //object in question
    public void Clickable()
    {
        Cursor.SetCursor(clickableCursor, Vector2.zero, CursorMode.Auto);
    }

    public void Default()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }
    
}
