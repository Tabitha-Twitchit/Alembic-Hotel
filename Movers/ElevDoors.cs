using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevDoors : MonoBehaviour
{
    private VariableTracker varTracker;
    private Yarnovator yarnElevator;
    private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        varTracker = GameObject.FindGameObjectWithTag("GameManager").GetComponent<VariableTracker>();
        yarnElevator = GameObject.FindGameObjectWithTag("Yarnovator").GetComponent<Yarnovator>();
        myAnimator = GetComponent<Animator>();
        if (varTracker != null)
        {
            varTracker.onElevOpen += OpenDoors;
        }
        if (yarnElevator != null)
        {
            yarnElevator.onElevClose += CloseDoors;
        }

        OpenDoors();
        Debug.Log("Got through start method on doors.");
    }

    public void OpenDoors()
    {
        myAnimator.SetBool("isOpening", true);
        myAnimator.SetBool("isClosing", false);
        Debug.Log("Called Open");
    }

    public void CloseDoors()
    {
        myAnimator.SetBool("isClosing", true);
        myAnimator.SetBool("isOpening", false);
        Debug.Log("Called Close");
    }

    private void OnDestroy()
    {
        if (varTracker != null)
        {
            varTracker.onElevOpen -= OpenDoors;
        }
        if (yarnElevator != null)
        {
            yarnElevator.onElevClose -= CloseDoors;
        }
    }
}
