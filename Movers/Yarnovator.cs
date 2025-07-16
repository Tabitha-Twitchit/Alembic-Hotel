using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

/// <summary>
/// The script pulls a $floor variable that is set in YarnSpinner dialog and matches it with 
/// an appropriate transform corresponding to the level of the building, which tells the elevator 
/// where to stop.
/// </summary>
public class Yarnovator : MonoBehaviour
{
    public Transform[] floor;
    public float speed;
    private InMemoryVariableStorage varStore;
    [SerializeField] bool elevatorReady;
    private float usableFloorNum;
    private GameObject player;

    private VariableTracker varTracker;
    public event Action onElevClose;


    private void Start()
    {
        varStore = GameObject.Find("Dialogue System").GetComponent<InMemoryVariableStorage>();
        player = GameObject.FindWithTag("Player");
        varTracker = GameObject.FindGameObjectWithTag("GameManager").GetComponent<VariableTracker>();
    }


    /*when the player steps and stays on the platform (having already spoken to the elevator attendant)
     * the elevator reads the $floor value, and outputs it as a float and checks that the player
     * is the one who triggered it. Then it reparents the player to the elevator. It then sets a bool
     that allows the elevator to be called during fixedupdate*/
    private void OnTriggerEnter(Collider other)
    {

        if (varStore.TryGetValue("$floor", out float floorNum) && other.tag == "Player" && varTracker.isElevatorIntentToGo == true)
        {
            other.transform.parent = this.transform;
            usableFloorNum = floorNum;
            StartCoroutine(SendElevator());
            ////Make it wait a couple sec and close the doors.
            ////Debug.Log("floor number:" + floorNum);
            //elevatorReady = true;
        }
    }
    //unparents the player when out of the trigger, and weirdly, you need to re DDOL the player because
    //unparenting it removes it from the DDOL scene...shrug.
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
            DontDestroyOnLoad(player);
            onElevClose?.Invoke();
            Debug.Log("In On trigger Exit?");
        }
    }

    /*If the elevator is ready to be called based on the criteria in OnTriggerEnter then run
     * GoToSelectedFloor. NOTE It may ultimately make more sense to remove this from fixed 
     * update and make it a coroutine so that it can more elegantly control doors, or reset elevator ready variables*/
    void FixedUpdate()
    {
        if (elevatorReady == true)
        {
            GoToSelectedFloor(usableFloorNum);
        }
    }


    /*checks the floor number as translated and passed in by onTriggerEnter and moves to the
    assigned public transform.*/
    void GoToSelectedFloor(float usableFloorNum)
    {
        for (int i = 0; i < 49; i++)
        {
            if (usableFloorNum == i)
            {
                transform.position = Vector3.MoveTowards(transform.position, floor[i].position, speed * Time.deltaTime);
            }
        }
        //intent is this runs after loop concludes, may need to rewrite as a coroutine.
        if(usableFloorNum == 1 || usableFloorNum == 0)
        {
            if (Vector3.Distance(transform.position, floor[1].position) < 0.01f || Vector3.Distance(transform.position, floor[0].position) < 0.01f)
            {
            varTracker.ElevDoorOpenOnly();
            usableFloorNum = float.NaN;
            elevatorReady = false;
            }
        }
    }
    /*Triggered mainly through ElevatorCall, a script on the NPC responsible for setting elevator 
     * floor variables. This receives the elevator stop transform closest to that NPC so the elev
     * knows where to go to pick up the player, in case the player ends up on a dif floor than 
     * where they last rode the elevator to.*/
    public IEnumerator CallElevator(Transform receivedTransform)
    {
        Vector3 startposition = transform.position;
        float elapsed = 0;

        while (elapsed < 1)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startposition, receivedTransform.position, elapsed / 1);
        }
        /*WEIRDLY the code responsible for moving the elevator normally did not work in the coroutine call.
         * Still don't know why.
         * transform.position = Vector3.MoveTowards(transform.position, receivedTransform.position, speed * Time.deltaTime);
        */
        //Debug.Log("Moving Towards"+ receivedTransform);
        elevatorReady = false;
        yield return null;
    }

    public IEnumerator SendElevator()
    {
        if (varTracker.isElevatorIntentToGo == true)
        {
            onElevClose?.Invoke();
            yield return new WaitForSeconds(3);
            elevatorReady = true;
            varTracker.isElevatorIntentToGo = false;
        }
    }

    //[YarnCommand("thedoors")]
    //public void DoorOpener()
    //{
    //    GameObject doors = new GameObject();
    //    doors = GameObject.Find("Doors");
    //    Animator myAnimator = doors.GetComponent<Animator>();
    //    myAnimator.SetBool("opening", true);
    //}
}