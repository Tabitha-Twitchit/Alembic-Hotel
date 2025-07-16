using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListRandomizer : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] tracks1;
    public AudioClip[] tracks2;
    public AudioClip[] tracks3;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            /*source.clip = tracks1[Random.Range(0, tracks1.Length)];
            source.Play(0);
            source.clip = tracks2[Random.Range(0, tracks2.Length)];
            source.Play(0);
            source.clip = tracks3[Random.Range(0, tracks3.Length)];
            source.Play(0);*/
     
            source.clip = tracks1[Random.Range(0, tracks1.Length)];
            source.PlayOneShot(source.clip);
            source.clip = tracks2[Random.Range(0, tracks2.Length)];
            source.PlayOneShot(source.clip);
            source.clip = tracks3[Random.Range(0, tracks3.Length)];
            source.PlayOneShot(source.clip);
    }


   
}
