// Oz
using UnityEngine;
using UnityEngine.UI;

public class ICDC : MonoBehaviour
{
    public enum StatType
    {
        Health,
        Energy,
        Speed,
        AttackSpeed,
        Damage,
        SightRange,
        HealthRegen,
        EnergyRegen,
    }
    public StatType statType;

    public Button increaser, decreaser;
    GameManager gameManager;

    [SerializeField] private float Increasement = .5f;
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
               //IncreaseCost();
            }
        });
        
        decreaser.onClick.AddListener(() =>
        {
            level--;
            if (gameManager.Spend(cost))
            {
                gameManager.player.Setter(statType, -Increasement);
                //IncreaseCost();
            }
        });
    }
    
    // Uncomment if needed
    // void IncreaseCost() => cost = System.Convert.ToInt32(Mathf.Pow(1.2f, level));
}
