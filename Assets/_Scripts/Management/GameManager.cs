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
    public float timeLapse = 1f;
    public UIStatUpdater uisu;
    public int EP;

    [Space]
    public UIPlayer player = new UIPlayer(); // FILL THIS VIA UIManager USING predefined go.
    public UIPlayer bot = new UIPlayer();     // FILL THIS VIA UIManager USING predefined go.

    [Space]
    [SerializeField] private GameObject FredContainer;
    [SerializeField] private GameObject BarneyContainer;

    private void Start()
    {
        uisu.UpdateTexts();
        clock.StartTick();
    }

    #region Earn / Spend

    public void Earn()
    {
        EP++;
        uisu.UpdateTexts();
    }

    public bool Spend()
    {
        if (EP > 0)
        {
            EP--;
            return true;
        }
        return false;
    }

    #endregion

    //[SerializeField] private bool debug = true;
    //public void Print(string playerName, string s)
    //{
    //    if (!debug) return;

    //    Debug.Log(playerName + "/     " + s);
    //}

    public void CheckBarney()
    {
        if (BarneyContainer.transform.childCount == 1)
        {
            UIManager.instance.WinFred();
        }
    }

    public void CheckFred()
    {
        if (FredContainer.transform.childCount == 1)
        {
            UIManager.instance.WinFred();
        }
    }
}