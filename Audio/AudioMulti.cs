using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMulti : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void OnCollissionEnter()
    {
        source.PlayOneShot(clip1);
        source.PlayOneShot(clip2);
        source.PlayOneShot(clip3);
        source.PlayOneShot(clip4);
    }
}
