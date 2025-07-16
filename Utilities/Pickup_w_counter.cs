using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// TABI NOTE This script employs a SEPARATE DDOL logic from your DDOL multi script and
/// as such that script should be deactivated on your player parent object! This logic
/// was employed because in BUILDS the counter was being updated by the initial counter
/// in the atrium even though this wasn't happening in editor. This method somehow better
/// enforces the needed order of ops/
/// </summary>

public class Pickup_w_counter : MonoBehaviour 
{
    public static Pickup_w_counter Instance { get; private set; }

    private TextMeshProUGUI countText;
    private long count;

    //More precisely destroys a repeat of the counter object so it doesn't update with 0 on return 
    // to the first scene
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        //Debug.Log("Pickup_w_counter Awake! Object: " + gameObject.name);
    }

    void Start()
    {
        AssignUI();
        SetCountText();
    }

    //if the player hits another collider that is setup as a trigger it checks if the tag says "packet" and if so, deactivates
    //it and adds one to the counter
    void OnTriggerEnter(Collider other)
    {
        //case switching checks the tag against the string in each case and executes given functions
        switch (other.gameObject.tag)
        {
            case "packet": 
                AddToCount(1);
                other.gameObject.SetActive(false); 
                break;
            case "kilopacket": 
                AddToCount(1024);
                other.gameObject.SetActive(false);
                break;
            case "megapacket": 
                AddToCount(1048576);
                other.gameObject.SetActive(false);
                break;
            case "gigapacket": 
                AddToCount(1073741824);
                other.gameObject.SetActive(false);
                break;
        }
        //Updates the UI to reflect the number under the hood    
        SetCountText();
    }


    //this defines the base text shown in the UI and appends it with the value set above

    void SetCountText()
    {
        countText.text = count.ToString();
    }

//Adds the packet num passed in as argument
    void AddToCount(long packetNum)
    {
        count += packetNum;
    }

//Assigns target UI
    private void AssignUI()
    {
        var counterObj = GameObject.Find("Packet Counter");
        if (counterObj != null)
        {
            countText = counterObj.GetComponent<TextMeshProUGUI>();
        }
    }
}
