// Oz
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    public enum DayState
    {
        Day,
        Night
    }
    public DayState dayState = DayState.Day;

    private int day = 0;
    private int hour = 0;
    private int minute = 0;
    private int second = 0;

    private const int DAY = 86400;
    private const int DAWN = 21600;
    private const int SUNSET = 0;
    private const int HOUR = 3600;
    private const int MINUTE = 60;

    public Action OnDawn;
    public Action OnSunset;

    private void Start()
    {
        InvokeRepeating(nameof(Tick), 0, 1);
    }

    private void Tick()
    {
        second++;
        if (second >= MINUTE)
        {
            minute++;
            second = 0;
        }

        if (minute > HOUR)
        {
            hour++;
            minute = 0;
        }

        if (hour > DAY)
        {
            day++;
            hour = 0;
        }

        if (hour == DAWN)
        {
            dayState = DayState.Day;
            OnSunset();
        }
        if (hour == SUNSET)
        {
            dayState = DayState.Night;
            OnDawn();
        }
    }

    public string GetTime() => hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");

    public string GetDay() => "Day: " + day.ToString("000"); 
}
