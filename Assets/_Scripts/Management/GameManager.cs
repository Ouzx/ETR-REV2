// Oz
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }
    #endregion
    
    public Clock clock;
    public UIPlayer uiPlayer = new UIPlayer(); // FILL THIS VIA UIManager USING predefined go.

    public Action OnUIUpdate;

    private void Start()
    {
        clock = GetComponent<Clock>();
    }

    #region EP
    private int EP;
    
    public int GetEP() => EP;
    public void SetEP(int value) => EP = value;

    #endregion

    #region RP
    private int RP;

    public int GetRP() => RP;
    public void SetRP(int value) => RP = value;
    #endregion

    #region Earn / Spend

    public void Earn(ref int value)
    {
        value++;
        OnUIUpdate?.Invoke();
    }

    public bool Spend(ref int value)
    {
        if (value - 1 >= 0)
        {
            value--;
            OnUIUpdate?.Invoke();
            return true;
        }
        return false;
    }

    #endregion

}
