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

    public int EP;

    [Space]
    public UIPlayer player = new UIPlayer(); // FILL THIS VIA UIManager USING predefined go.
    public UIPlayer bot = new UIPlayer();     // FILL THIS VIA UIManager USING predefined go.
   
    public Action OnUIUpdate;
    
    
    private void Start()
    {
        clock = GetComponent<Clock>();
    }

    #region Earn / Spend

    public void Earn()
    {
        EP ++;
        OnUIUpdate?.Invoke();
    }

    public bool Spend(int value)
    {
        var t = EP - value;
        if (t >= 0)
        {
            EP = t;
            OnUIUpdate?.Invoke();
            return true;
        }
        return false;
    }

    #endregion

}
