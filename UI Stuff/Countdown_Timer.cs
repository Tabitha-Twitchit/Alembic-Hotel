using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown_Timer : MonoBehaviour
{
    public Text losttext;
    public Text timeText;
    public float startingtime = 20f;
    private float currenttime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        currenttime = startingtime;
    }

    // Update is called once per frame
    void Update()
    {
        currenttime -= Time.deltaTime;
        timeText.text = currenttime.ToString("0");

        if (currenttime <=0)
        {
            currenttime = 0;
        }
    }

    private void FixedUpdate()
    {
        if(currenttime <= 0)
        {
            losttext.text = "You Lose!";
        }
    }
}
