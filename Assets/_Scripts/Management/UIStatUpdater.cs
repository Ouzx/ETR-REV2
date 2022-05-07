using UnityEngine;
using UnityEngine.UI;

public class UIStatUpdater : MonoBehaviour
{
    public Text[] texts;
    GameManager gm;
    void Start()
    {
        gm = GameManager.instance;
        gm.OnUIUpdate += UpdateTexts;
    }
    void UpdateTexts()
    {
        texts[0].text = gm.player.Health.ToString();
        texts[1].text = gm.player.Energy.ToString();
        texts[2].text = gm.player.Speed.ToString();
        texts[3].text = gm.player.AttackSpeed.ToString();
        texts[4].text = gm.player.Damage.ToString();
        texts[5].text = gm.player.SightRange.ToString();
        texts[6].text = gm.player.HealthRegen.ToString();
        texts[7].text = gm.player.EnergyRegen.ToString();
        texts[8].text = gm.player.Power.ToString();
        texts[9].text = gm.EP.ToString();
    }
}
