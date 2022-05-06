using UnityEngine;
using TMPro;

public class UIStatUpdater : MonoBehaviour
{
    public TextMeshProUGUI[] texts;
    GameManager gm;
    void Start()
    {
        gm = GameManager.instance;
        gm.OnUIUpdate += UpdateTexts;
    }
    void UpdateTexts()
    {
        texts[0].text = gm.uiPlayer.health.ToString();
        texts[1].text = gm.uiPlayer.energy.ToString();
        texts[2].text = gm.uiPlayer.speed.ToString();
        texts[3].text = gm.uiPlayer.attackSpeed.ToString();
        texts[4].text = gm.uiPlayer.damage.ToString();
        texts[5].text = gm.uiPlayer.sightRange.ToString();
        texts[6].text = gm.uiPlayer.healthRegen.ToString();
        texts[7].text = gm.uiPlayer.energyRegen.ToString();
        texts[8].text = gm.uiPlayer.power.ToString();
        texts[9].text = gm.EP.ToString();
        texts[10].text = gm.RP.ToString();
    }
}
