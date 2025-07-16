using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DayUpdater : MonoBehaviour
{
    [SerializeField] private VariableTracker varTracker;
    private TMP_Text dayText;
    //private int currentDay = 1;


    private void Start()
    {
        dayText = GetComponent<TMP_Text>();
        if (varTracker != null)
        {
            //varTracker.onShowDay += UpdateDay;
        }
    }
     
    void UpdateDay(int currentDay)
    {
        dayText.text = currentDay.ToString();
    }

    private void OnDestroy()
    {
        //varTracker.onShowDay -= UpdateDay;
    }
}
