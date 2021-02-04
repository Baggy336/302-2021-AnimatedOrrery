using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIControl : MonoBehaviour
{
    // Declare the timescale
    public static float time = 1;
    EventSystem events;
    
    public Transform targetPosition;

    // Declate the textmeshpro 
    public TMP_Text textTime;

    void Start()
    {
        TimeSliderUpdate(1);
        // Get the event system component
        events = GetComponentInChildren<EventSystem>();
        
    }
    void Update()
    {
        // If events aren't present
        if (events == null) return;
        if (events.currentSelectedGameObject == null) // If nothing is currently selected
        {
            if (events.firstSelectedGameObject != null)
                events.SetSelectedGameObject(events.firstSelectedGameObject); // Set the first selected object
        }
    }

    public void TimeSliderUpdate(float amt)
    {
        time = amt;
        textTime.text = System.Math.Round(time, 2).ToString();
    }
    
}
