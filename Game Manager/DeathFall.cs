using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathFall : MonoBehaviour {

    /// <summary>
    /// Brings the player back to their room if they fall off anything.
    /// </summary>
    
    private VariableTracker varTracker;
    public bool isFalling = false;
    public int fallDistance;

    private void OnEnable()
    {
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        //SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        varTracker = GameObject.Find("GameManager").GetComponent<VariableTracker>();
    }
    void Update()
    {
        //This value will need checking against, say the ext stairs scene to
        //be sure the dimensions work.
        if (gameObject.transform.position.y <= -fallDistance && !isFalling)
        {
            isFalling = true;
            Debug.Log("IsFalling pre coroutine?" + isFalling);
            varTracker.GoToRoom();
            //could maybe be modified to call another similar func to put
            //them in bed?
            StartCoroutine(FallingRefresh());
        }
    }

    IEnumerator FallingRefresh()
    {
        yield return new WaitForSeconds(10);
        isFalling = false;
        Debug.Log("IsFalling post coroutine?" + isFalling);
    }
}