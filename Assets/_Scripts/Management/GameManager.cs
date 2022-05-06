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
    // Tum botlar player uzerinden erisiyor. TODO: Bu durumu degistir.
    public UIPlayer player = new UIPlayer(); // FILL THIS VIA UIManager USING predefined go.
    public UIPlayer bot = new UIPlayer();     // FILL THIS VIA UIManager USING predefined go.
    public Action OnUIUpdate;

    public int EP;
    
    private void Start()
    {
        clock = GetComponent<Clock>();
    }

    #region Earn / Spend

    public void Earn( int value)
    {
        EP += value;
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
