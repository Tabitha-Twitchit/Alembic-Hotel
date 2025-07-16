using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectText : MonoBehaviour
{
    //the public string is where the text to be printed in the players UI comes from
    //public string text;
    public List<string> words;


    public string rando()
    {
        return words[Random.Range(0, words.Count )];
    }


    //private void rando(int maxInt)
    //{ 
        
        //int chosen = Random.Range(0, 4);
        //text = chosen.ToString();

    //}
    
}

