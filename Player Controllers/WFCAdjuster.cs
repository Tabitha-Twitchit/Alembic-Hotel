using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WFCAdjuster : MonoBehaviour
{
    /// <summary>
    /// The point of this is to handle the difference in scale between WFC scenes and other scenes.
    /// WFC scenes have each block scaled at 1 x 1 x 1 meaning the def char controller used here is
    /// both too large and too fast. Thus we need to adjust it on the fly.
    /// </summary>
    /// 

    private VariableTracker varTracker;
    private FirstPersonController fpc;
    private Vector3 originalScale;
    public float regSpeed = 5;
    private Vector3 smallScale;
    //public float smallScaleFactor = 0.5f;
    public float smallSpeed = 3;
    //public float regScaleFactor = 2;

    // Start is called before the first frame update
    void Start()
    {
        varTracker = GameObject.FindGameObjectWithTag("GameManager").GetComponent<VariableTracker>();
        fpc = GetComponent<FirstPersonController>();
        originalScale = new Vector3(1f, 1f, 1f);
        smallScale = new Vector3(0.5f, 0.5f, 0.5f);
        if (varTracker != null)
        {
            varTracker.onWFCScene += DownScaler;
            varTracker.onNormScene += UpScaler;
        }
    }
    private void OnDestroy()
    {
        if (varTracker != null)
        {
        varTracker.onNormScene -= UpScaler;
        varTracker.onWFCScene -= DownScaler;
        }
    }

    public void DownScaler()
    {
        //Debug.Log("We in here?");
        transform.localScale = smallScale;
        fpc.isWalking = true;
        fpc.walkSpeed = smallSpeed;
    }

    public void UpScaler()
    {
        transform.localScale = originalScale;
        fpc.isWalking = true;
        fpc.walkSpeed = regSpeed;
    }
}
