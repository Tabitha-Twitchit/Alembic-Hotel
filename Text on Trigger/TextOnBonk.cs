using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//goes on player
public class TextOnBonk : MonoBehaviour
{
    //player has childed text object which imparts formatting
    //private GameObject fountaintext;
    private GameObject tmpparser;

    //on trigger if tagged as text object then get the components text string imparted by its ObjectText
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "textobj")
        {
            HUDText.instance.text.gameObject.SetActive(true);
            HUDText.instance.text.text = other.GetComponent<ObjectText>().rando();
        }
    }

    //when you go away turn off
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "textobj")
        {
            HUDText.instance.text.gameObject.SetActive(false);
        }
    }
}
//can you get a text object attached to the bonked into obj
//instead of the text from the string if you need to inheriot 
//formatting unique to that object.