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


    private void Start()
    {
        gameManager = GameManager.instance;
        increaser.onClick.AddListener(() =>
        {
            if (gameManager.Spend())
            {
                gameManager.player.Setter(statType, Increasement);
                gameManager.uisu.UpdateTexts();
            }
        });

        decreaser.onClick.AddListener(() =>
        {
            if (gameManager.Spend())
            {
                gameManager.player.Setter(statType, -Increasement);
                gameManager.uisu.UpdateTexts();
            }
        });
    }
}
