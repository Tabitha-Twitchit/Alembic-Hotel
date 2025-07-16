using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Camera))]

/*A Character controller that essentially behaves like a NoClip debug cam.
 * NOTE this implimentation changes input axis names for Horizontal and Vertical to "Move X" and "Move Y" and Mouse X, Y to "Look X, Y"
 */

public class FlyingController : MonoBehaviour
{
    public float acceleration = 50; // how fast you accelerate
    public float accSprintMultiplier = 4; // how much faster you go when "sprinting"
    public float lookSensitivity = 1; // mouse look sensitivity
    public float dampingCoefficient = 5; // how quickly you break to a halt after you stop your input
    public bool focusOnEnable = true; // whether or not to focus and lock cursor immediately on enable

    private Camera playerCamera;

    Vector3 velocity; // current velocity

    static bool Focused
    {
        get => Cursor.lockState == CursorLockMode.Locked;
        set
        {
            Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = value == false;
        }
    }
    
    void OnEnable()
    {
        if (focusOnEnable) Focused = true;
    }

    void OnDisable() => Focused = false;
    
    private void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        
        // Input
        //the result of the focused function is that when clicked out of the game window, it isn't still
        //taking input into the game.
        if (Focused)
            UpdateInput();
        else if (Input.GetMouseButtonDown(0))
            Focused = true;
        
        // Physics
        velocity = Vector3.Lerp(velocity, Vector3.zero, dampingCoefficient * Time.deltaTime);
        transform.position += velocity * Time.deltaTime;
    }

    void UpdateInput()
    {
        // Position
        velocity += GetAccelerationVector() * Time.deltaTime;

        /*
      // Rotation (the original rotation function from the script. My modded on is below. Modded
      //to fix the fact that this rotates the capsule and offsets the camera when used with a toggle
      //between normal fp control and flying fp
      Vector2 mouseDelta = lookSensitivity * new Vector2(Input.GetAxis("Look X"), -Input.GetAxis("Look Y"));
      Quaternion rotation = transform.rotation;
      Quaternion horiz = Quaternion.AngleAxis(mouseDelta.x, Vector3.up);
      Quaternion vert = Quaternion.AngleAxis(mouseDelta.y, Vector3.right);
      transform.rotation = horiz * rotation * vert;
      */

        Vector2 mouseDelta = lookSensitivity * new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        Quaternion rotation = playerCamera.transform.localRotation;
        Quaternion horiz = Quaternion.AngleAxis(mouseDelta.x, Vector3.up);
        Quaternion vert = Quaternion.AngleAxis(mouseDelta.y, Vector3.right);
        playerCamera.transform.localRotation = horiz * rotation * vert;
        
        // Leave cursor lock
        if (Input.GetKeyDown(KeyCode.Escape))
            Focused = false;
        
    }

    Vector3 GetAccelerationVector()
    {
        Vector3 moveInput = default;

        void AddMovement(KeyCode key, Vector3 dir)
        {
            if (Input.GetKey(key))
                moveInput += dir;
        }

        AddMovement(KeyCode.W, Vector3.forward);
        AddMovement(KeyCode.S, Vector3.back);
        AddMovement(KeyCode.D, Vector3.right);
        AddMovement(KeyCode.A, Vector3.left);
        AddMovement(KeyCode.Space, Vector3.up);
        AddMovement(KeyCode.LeftControl, Vector3.down);
        Vector3 direction = playerCamera.transform.TransformVector(moveInput.normalized);
        
        /*Line above replaced the original below line to make the char controller move in the direction 
         * the cam is facing rather than the transform capsule. So that it plays well with the toggle-
         * able grounded first person and flying first person controller.
         * Vector3 direction = transform.TransformVector(moveInput.normalized);
         */

        if (Input.GetKey(KeyCode.LeftShift))
            return direction * (acceleration * accSprintMultiplier); // "sprinting"
        return direction * acceleration; // "walking"
    }
}