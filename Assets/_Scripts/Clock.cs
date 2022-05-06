// Oz
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    private const int DAY = 86400;
    private const int DAWN = 21600;
    private const int SUNSET = 0;
    private const int HOUR = 3600;
    private const int MINUTE = 60;
    
    public enum DayState
    {
        Day,
        Night
    }
    private static DayState dayState;
    public static DayState GetDayState() => dayState;

    private int day = 0;
    private int hour = 0;
    private int minute = 0;
    private int second = 0;

    public Action OnDawn;
    public Action OnSunset;
    public Action OnTick;
    
    public bool clockState = false;
    public void StartTick() => InvokeRepeating(nameof(Tick), 0, 1);

    private void Tick()
    {
        if (!clockState) return;

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
            OnDawn();
        }

        if (hour == SUNSET)
        {
            dayState = DayState.Night;
            OnSunset();
        }
        OnTick();
        second++;
    }

    public string GetTime() => hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");

    public string GetDay() => "Day: " + day.ToString("000");

}
