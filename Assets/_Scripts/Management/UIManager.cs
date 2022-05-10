// Oz
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    #region Singleton

    public static UIManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion

    [SerializeField] private RectTransform Main, WON;
    [SerializeField] private Text WONText;
    public void WinBarney()
    {
        Main.gameObject.SetActive(false);
        WONText.text = "You LOST!";
    }

    public void WinFred()
    {
        Main.gameObject.SetActive(false);
        WONText.text = "You WIN!";
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
