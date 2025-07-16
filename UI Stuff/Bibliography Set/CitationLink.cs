using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CitationLink : MonoBehaviour //, IPointerClickHandler
{
    //A class to hold the mapping of node titles to Sprites
    [System.Serializable]
    public class NodeImageMapping
    {
        public string citTitle;
        public Sprite sprite;
    }

    public Image qrImage;

    // List to populate the dictionary in the inspector
    public List<NodeImageMapping> nodeImageMappings;
    
    //dictionary for quick lookup
    private Dictionary<string, Sprite> nodeImageDict;

    void Start()
    {
        if (qrImage == null)
        {
            Debug.LogError("QR Image not assigned in inspector");
        }

        //Initialize the dictionary
        nodeImageDict = new Dictionary<string, Sprite>();
        foreach (var mapping in nodeImageMappings)
        {
            if (!nodeImageDict.ContainsKey(mapping.citTitle))
            {
                nodeImageDict.Add(mapping.citTitle, mapping.sprite);
            }
            else
            {
                Debug.LogWarning($"Duplicate node title found: {mapping.citTitle}");
            }
        }
    }

    public string CitNameGetter()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        if (clickedButton != null)
        {
            TextMeshProUGUI citComponent = clickedButton.GetComponentInChildren<TextMeshProUGUI>();
            if (citComponent != null)
            {
                return citComponent.text;
            }
        }
            return null;
    }

    public void QRShower()
    {
        //Debug.Log("Button IS Pressed");
        string thisCit = CitNameGetter();
        if (thisCit == null) return;

        if (nodeImageDict.TryGetValue(thisCit, out Sprite correspondingSprite))
        {
            Debug.Log($"Button Citation Text: {thisCit}");
            Debug.Log($"Showing image: {correspondingSprite.name}");

            qrImage.sprite = correspondingSprite;
            qrImage.gameObject.SetActive(true);
        }
    }
}