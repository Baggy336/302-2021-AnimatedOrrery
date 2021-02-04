using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    // Declare the timescale
    public static float time = 1;

    // Declate the textmeshpro 
    public TMP_Text textTime;

    void Start()
    {
        TimeSliderUpdate(1);
    }
    void Update()
    {
       
    }

    public void TimeSliderUpdate(float amt)
    {
        time = amt;
        textTime.text = System.Math.Round(time, 2).ToString();
    }
}
