using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Yarn.Unity;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCoolDown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode roomKey = KeyCode.P;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float grounDistance = 0.4f;
    //public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    
    Rigidbody rb;

    //Stuff used for checking variables elsewhere
    private VariableTracker varTracker;
    //private bool isInRoom = false;
    private Pickup_w_counter packetCounter;
    private GameObject consoleScreen;
    //private bool isConsoleOn = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
        readyToJump = true;

        varTracker = GameObject.Find("GameManager").GetComponent<VariableTracker>();
        packetCounter = GameObject.Find("Player").GetComponent<Pickup_w_counter>();
        //consoleScreen = GameObject.Find("UI Input Window");
        //consoleScreen.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //groundcheck
        //grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        grounded = Physics.CheckSphere(groundCheck.position, grounDistance, whatIsGround);
        
        MyInput();
        SpeedControl();
        //handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCoolDown);   
        }

        //if(Input.GetKey(roomKey) && varTracker.isRoomKeyed)
        /*
        {
            /*As you do more scenes you will need to refactor this to track the previous scene.
             * Some kind of conditional for the current scene # that excludes the hotel room.
             * So that when you hit P again it takes you to the scene you were in before the hotel
             * room.
             */
        /*
            isInRoom =! isInRoom;
            if (isInRoom)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
           
        }
        */
    }

    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        
        //in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true; 
    }
}
