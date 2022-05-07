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
        texts[0].text = gm.player.health.ToString();
        texts[1].text = gm.player.energy.ToString();
        texts[2].text = gm.player.speed.ToString();
        texts[3].text = gm.player.attackSpeed.ToString();
        texts[4].text = gm.player.damage.ToString();
        texts[5].text = gm.player.sightRange.ToString();
        texts[6].text = gm.player.healthRegen.ToString();
        texts[7].text = gm.player.energyRegen.ToString();
        texts[8].text = gm.player.power.ToString();
        texts[9].text = gm.EP.ToString();
    }
}
