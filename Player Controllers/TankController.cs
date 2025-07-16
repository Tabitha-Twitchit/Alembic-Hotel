using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        
        //moves the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        
        //Note you can add "* forwardInput" after "* horizontalInput" to this last method to turn it into more of a car controller,
        //I.e. it needs to also move forwrad to be able to turn.
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
            
    }
}
