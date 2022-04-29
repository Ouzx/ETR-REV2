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

    private delegate void Refresh();
    private void RefreshUI(Refresh refresh=null)
    {
        refresh?.Invoke();
        OnUIUpdate?.Invoke();
    }

    #region EP
    private int EP;
    
    public void EarnEP() => RefreshUI(() => EP++);
    public bool SpendEP()
    {
        if (EP - 1 >= 0)
        {
            EP--;
            RefreshUI();
            return true;
        }
        OnUIUpdate?.Invoke();
        return false;
    }

    public int GetEP() => EP;
    public void SetEP(int value) => EP = value;

    #endregion

    #region RP
    private int RP;

    public void EarnRP() => RefreshUI(() => RP++);
    public bool SpendRP()
    {
        if (RP - 1 >= 0)
        {
            RP--;
            RefreshUI();
            return true;
        }
        OnUIUpdate?.Invoke();
        return false;
    }

    public int GetRP() => RP;
    public void SetRP(int value) => RP = value;
    #endregion
}
