using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //using the boolean operator we check if the backslash is pressed down
        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            //this performs another boolean check, wherein if the current timescale is 1, aka normal...
            if (Time.timeScale == 1)
            {
                //then it is set to zero, aka time freakin' stops!
                Time.timeScale = 0;
            }
            //BUT! if time is anything else then it is set back to normal. I wonder what other values we could try?
            //(put an "f" after any nonwhole number to designate it as a floating point number for...math reasons)
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
