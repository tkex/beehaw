using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Clock : MonoBehaviour
{
    [SerializeField]
    Transform hourHand, minuteHand, secondsHand;

    public DateTime date;

    const float hoursToDegrees = 30f, minutesToDegrees = 6f, secondsToDegrees = 6f;
    string oldSeconds;

    // Start is called before the first frame update
    void Start()
    {
        DateTime currentDate = DateTime.Now;
        date = currentDate;
        
        // set initial clock hands position
        TimeSpan time = DateTime.Now.TimeOfDay;
        hourHand.transform.Rotate(0f, hoursToDegrees * (float)time.TotalHours, 0f);
        minuteHand.transform.Rotate(0f, minutesToDegrees * (float)time.TotalMinutes, 0f);
        secondsHand.transform.Rotate(0f, secondsToDegrees * (float)time.TotalSeconds, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        string seconds = DateTime.Now.ToString("ss");

        if (seconds != oldSeconds)
        {
            UpdateTimer();
        }
        oldSeconds = seconds;
    }

    void UpdateTimer() 
    {
        int secondsInt = int.Parse(DateTime.Now.ToString("ss"));
        int minutesInt = int.Parse(DateTime.Now.ToString("mm"));
        int hourInt = int.Parse(DateTime.Now.ToLocalTime().ToString("hh"));
        //print(hourInt + ": " + minutesInt + ": " + secondsInt);

        secondsHand.transform.Rotate(0f, secondsToDegrees, 0f);

        if (secondsInt == 0)
        {
            minuteHand.transform.Rotate(0f, minutesToDegrees, 0f);
        }

        if (minutesInt == 0)
        {
            hourHand.transform.Rotate(0f, hoursToDegrees, 0f);
        }
    }

}
