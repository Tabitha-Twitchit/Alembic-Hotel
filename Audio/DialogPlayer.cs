using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogPlayer : MonoBehaviour
{
    /// <summary>
    /// right now this uses separate yarn functions to play dialog. Ideally there would be
    /// a variable check when starting a new convo that sets the current Clips Array from 
    /// the potential clip arrays of different character, probably via string handed from 
    /// Yarn. Didn't have time to play with this under the deadline. 
    /// </summary>
    public AudioClip[] conciergeClips;
    public AudioClip[] yonicaClips;
    public AudioClip beeSounds;
    private AudioSource audioSource;
    private int currentClipIndex = 0;
    [SerializeField] private VariableTracker varTracker;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    [YarnCommand("conciergeNextdialog")]
    public void PlayConciergeNextClip()
    {
        if(varTracker.beeModule)
        {
            audioSource.PlayOneShot(beeSounds);
        }
        else {
            if (currentClipIndex < conciergeClips.Length)
            {
                audioSource.PlayOneShot(conciergeClips[currentClipIndex]);
                currentClipIndex++;
            }
            if (currentClipIndex >= conciergeClips.Length)
            {
                DialogIndexReset();
            }
        }
         
    }



    [YarnCommand("yonicaNextdialog")]
    public void PlayYonicaNextClip()
    {
        if (varTracker.beeModule)
        {
            audioSource.PlayOneShot(beeSounds);
        }
        else
        {
            if (currentClipIndex < yonicaClips.Length)
            {
                audioSource.PlayOneShot(yonicaClips[currentClipIndex]);
                currentClipIndex++;
            }
            if (currentClipIndex >= yonicaClips.Length)
            {
                DialogIndexReset();
            }
        }
    }
    [YarnCommand("dialogReset")]
    public void DialogIndexReset()
    {
        currentClipIndex = 0;
    }
}