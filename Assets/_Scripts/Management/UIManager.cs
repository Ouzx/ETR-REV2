// Oz
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button increaser, decreaser;
    GameManager gameManager;

    [SerializeField] private float Increasement = .5f;
    private string statType;
    int level = 0;
    int cost = 1;

    private void Start()
    {
        gameManager = GameManager.instance;
        increaser.onClick.AddListener(() => {
            level++;
            if (gameManager.Spend(cost))
            {
                gameManager.player.Setter(statType, Increasement);
                IncreaseCost();
            }
        });
        
        decreaser.onClick.AddListener(() =>
        {
            level--;
            if (gameManager.Spend(cost))
            {
                gameManager.player.Setter(statType, -Increasement);
                IncreaseCost();
            }
        });
    }

    void IncreaseCost() => cost = System.Convert.ToInt32(Mathf.Pow(1.2f, level));
}
