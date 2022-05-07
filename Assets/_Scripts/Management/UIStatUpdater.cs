using UnityEngine;
using UnityEngine.UI;

public class UIStatUpdater : MonoBehaviour
{
    public Text[] texts;
  
    public void UpdateTexts()
    {
        GameManager.instance.player.UpdatePower();
        texts[0].text = GameManager.instance.player.Health.ToString();
        texts[1].text = GameManager.instance.player.Energy.ToString();
        texts[2].text = GameManager.instance.player.Speed.ToString();
        texts[3].text = GameManager.instance.player.AttackSpeed.ToString();
        texts[4].text = GameManager.instance.player.Damage.ToString();
        texts[5].text = GameManager.instance.player.SightRange.ToString();
        texts[6].text = GameManager.instance.player.HealthRegen.ToString();
        texts[7].text = GameManager.instance.player.EnergyRegen.ToString();
        texts[8].text = GameManager.instance.player.Power.ToString();
        texts[9].text = GameManager.instance.EP.ToString();
    }
}
