using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimedControllerCollector : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public float speed;
    public float startingTime = 20f;
    public Text countText;
    public Text winText;
    public Text lostText;
    public Text timeText;

    private Rigidbody rb;
    private int count;
    private float currentTime = 0f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        lostText.text = "";
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        timeText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        //   time += Time.deltaTime; 

        if (currentTime <= 0)
        {
            lostText.text = "You Lose!";
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();

        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "Youn Win";
        }
    }

}
