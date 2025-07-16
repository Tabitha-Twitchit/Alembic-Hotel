using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOnTrigger : MonoBehaviour
{
    public Text quote;

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Player")
        {
            quote.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == "Player")
        {
            quote.gameObject.SetActive(false);
        }
    }
}
