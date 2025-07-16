using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerRay : MonoBehaviour
{
    //the distance the ray will travel in both the debug and the game
    private Behaviour firstPersonController;
    private CharacterController characterController;
    public float range;
    private GameObject reticle, reticleTwo, reticleThree;
    [SerializeField] private VariableTracker varTracker;
    //private VariableTracker varTracker;

    /*a very vlexible script that casts a ray on a given input from a given point, presently the mouse location
     * but could be made to be the screen center etc. The ray can be adapted in different IF statements to 
     * check for a variety of tags and if so can send a message to the tagged object hit by the ray and call
     * methods in scripts on that game object. Here, it tells an NPC to face the player when hit by a ray so 
     * that they can have a conversation. A good ray tutorial:
     * https://gamedevbeginner.com/raycasts-in-unity-made-easy/
     */

    //you could potentially redo this as an event broadcaster
    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        //varTracker = GameObject.Find("GameManager").GetComponent<VariableTracker>();
        firstPersonController = GetComponent<FirstPersonController>();
        characterController = GetComponent<CharacterController>();
        if (varTracker != null)
        {
            varTracker.onObjectInteract += PlayerUIMode;
            varTracker.onObjectExit += ExitPlayerUIMode;
            varTracker.onIntroFade += ExitPlayerUIMode;
        }

        reticle = GameObject.Find("MouthReticleA");
        reticleTwo = GameObject.Find("MouthReticleB");
        reticleThree = GameObject.Find("Object Reticle");

        PlayerUIMode();
    }

    void Update()
    {
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.65f, 0.6f, 0f));
            //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            Debug.DrawRay(ray.origin, ray.direction * range);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range) && hit.collider.gameObject.CompareTag("NPC"))
            {
                reticle.SetActive(true);
                reticleTwo.SetActive(true);
                reticleThree.SetActive(false);
            }
            else if (Physics.Raycast(ray, out hit, range) && hit.collider.gameObject.CompareTag("Object"))
            {
                reticle.SetActive(false);
                reticleTwo.SetActive(false);
                reticleThree.SetActive(true);
            }
            else
            {
                reticle.SetActive(false);
                reticleTwo.SetActive(false);
                reticleThree.SetActive(false);
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray2 = Camera.main.ViewportPointToRay(new Vector3(0.65f, 0.6f, 0f));
            //Ray ray2 = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            Debug.DrawRay(ray2.origin, ray2.direction * range);

            RaycastHit hit;
            if (Physics.Raycast(ray2, out hit, range))
            {
                if (hit.collider.gameObject.CompareTag("NPC") && hit.collider.gameObject.name == "JosephSmith")
                {
                    //this method should only ever be called from JSS or will cause font fuckups!
                    varTracker.JSSBeeTextSetter(); 
                }
                else if (hit.collider.gameObject.CompareTag("NPC"))
                {
                    hit.transform.SendMessage("HitByRay");
                    YarnInteractable currentNPCYarn = hit.collider.gameObject.GetComponent<YarnInteractable>();
                    Debug.Log("hit NPC");
                    if (currentNPCYarn != null)
                    {
                        currentNPCYarn.convoStarter();
                    }
                }
                else if (hit.collider.gameObject.CompareTag("Object") && hit.collider.gameObject.name == "Bed")
                {
                    varTracker.BedUI();
                }
                else if (hit.collider.gameObject.CompareTag("Object") && hit.collider.gameObject.name == "Suitcase")
                {
                    varTracker.SuitcaseUI();
                }
                else if(hit.collider.gameObject.CompareTag("Object") && hit.collider.gameObject.name == "magazine")
                {
                    varTracker.BiblioUI();
                    //TABI NOTE: Old Yarn Biblio starter
                    //YarnInteractable currentNPCYarn = hit.collider.gameObject.GetComponent<YarnInteractable>();
                    //if (currentNPCYarn != null)
                    //{
                    //    currentNPCYarn.convoStarter();
                    //}
                }
            }
        }
    }
    private void OnDestroy()
    {
        if(varTracker != null)
        {
        varTracker.onObjectInteract -= PlayerUIMode;
        varTracker.onObjectExit -= ExitPlayerUIMode;
        varTracker.onIntroFade += ExitPlayerUIMode;
        }
    }

    //##################
    //TABI NOTE THIS IS A CRUCIAL FUNCTION that governs when you are in UI Mode and when NOT 
    public void PlayerUIMode()
    {
        Debug.Log("reached playerUI mode");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        firstPersonController.enabled = false;
        characterController.enabled = false;
    }

    public void ExitPlayerUIMode()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        firstPersonController.enabled = true;
        characterController.enabled = true;
    }
}
