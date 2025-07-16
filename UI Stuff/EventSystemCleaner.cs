using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemCleaner : MonoBehaviour
{
    void Awake()
    {
        EventSystem[] systems = FindObjectsOfType<EventSystem>();

        // If there's more than one, this is the duplicate
        if (systems.Length > 1)
        {
            foreach (EventSystem es in systems)
            {
                if (es.gameObject.scene.name != null && es.gameObject.scene.isLoaded)
                {
                    Destroy(es.gameObject); // Only destroy the one that just spawned
                }
            }
        }
    }
    void Start()
    {
        var systems = FindObjectsOfType<EventSystem>();
        Debug.Log("EventSystems in memory: " + systems.Length);
        foreach (var es in systems)
        {
            Debug.Log("EventSystem name: " + es.name + " | Scene: " + es.gameObject.scene.name);
        }
    }

}
