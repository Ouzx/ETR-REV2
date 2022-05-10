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
    
    public enum DayState
    {
        Day,
        Night
    }
    private static DayState dayState;
    public static DayState GetDayState() => dayState;

    private int day = 0;
    private int hour = 6;

    public Action OnDawn;
    public Action OnSunset;
    public Action OnTick;
    
    public bool clockState = false;
    public void StartTick() => InvokeRepeating(nameof(Tick), 0, GameManager.instance.timeLapse);

    private void Tick()
    {
        if (!clockState) return;

        if (hour == DAY)
        {
            day++;
            hour = 0;
        }

        if (hour == DAWN)
        {
            dayState = DayState.Day;
            OnDawn?.Invoke();
        }

        if (hour == SUNSET)
        {
            dayState = DayState.Night;
            OnSunset?.Invoke();
        }
        OnTick?.Invoke();
        hour++;
        clockText.text = $"{GetDay()} // {GetTime()}";
    }

    public string GetTime() => hour.ToString("00") + ":" + "00";

    public string GetDay() => day.ToString("00");

}
