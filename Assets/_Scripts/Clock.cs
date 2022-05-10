// Oz
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{
    [SerializeField] private Text clockText;

    private const int DAY = 24;
    private const int DAWN = 6;
    private const int SUNSET = 20;
    private const int HOUR = 60;
    private const int MINUTE = 60;
    
    public enum DayState
    {
        Day,
        Night
    }
    private static DayState dayState;
    public static DayState GetDayState() => dayState;

    private int day = 0;
    private int hour = 6;
    private int minute = 0;
    private int second = 0;

    public Action OnDawn;
    public Action OnSunset;
    public Action OnTick;
    
    public bool clockState = false;
    private bool  setHour, setDay, setDawn = true, setSunset;
    public void StartTick() => InvokeRepeating(nameof(Tick), 0, 0.0001f);

    private void Tick()
    {
        if (!clockState) return;

        if (second == MINUTE)
        {
            minute++;
            second = 0;
            setHour = true;
        }

        if (minute == HOUR && setHour)
        {
            hour++;
            minute = 0;
            
            setHour = false;
            setDay = true;
            setDawn = true;
            setSunset = true;
        }

        if (hour == DAY && setDay)
        {
            day++;
            hour = 0;
            setDay = false;
        }

        if (hour == DAWN && setDawn)
        {
            dayState = DayState.Day;
            OnDawn();
            setDawn = false;
        }

        if (hour == SUNSET && setSunset )
        {
            dayState = DayState.Night;
            OnSunset();
            setSunset = false;
        }
        OnTick();
        second++;

        clockText.text = $"{GetDay()} // {GetTime()}";
    }

    public string GetTime() => hour.ToString("00") + ":" + minute.ToString("00") /*+ ":" + second.ToString("00")*/;

    public string GetDay() => day.ToString("00");

}
