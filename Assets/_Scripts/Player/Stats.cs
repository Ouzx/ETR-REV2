// Oz
using UnityEngine;

public class Stats : MonoBehaviour
{
    public System.Action DoWhenDied;

    [HideInInspector] public UIPlayer player;

    private void Start()
    {
        name = NameGen.GetName();
        player = GetComponent<Player>().playerType == Player.PlayerType.Player ?
                                                        GameManager.instance.player :
                                                        GameManager.instance.bot;
        GameManager.instance.bot.UpdatePower();
        
        SetHealth(player.Health);
        SetEnergy(player.Energy);
        SetHungeress(0);
        SetIsHungry(true);
    }

    #region NAME
    private new string name;

    public string GetName() => name;
    #endregion

    #region Power
    public float GetPower() => player.Power;
    #endregion

    #region Health
    private float health;

    public float GetHealth() => health;
    public float GetHealthRegen() => player.HealthRegen;

    public void SetHealth(float health)
    {
        var tempHealth = health + this.health;
        if (tempHealth < 0)
        {
            this.health = 0;
            DoWhenDied?.Invoke();
        }
        if (tempHealth < player.Health)
            this.health = tempHealth;
        else
            this.health = player.Health;
    }
    #endregion

    #region Energy
    private float energy;

    public float GetEnergy() => energy;
    public float GetSpeed() => player.Speed;
    public float GetEnergyRegen() => player.EnergyRegen;
    public float GetWalkingCost() => player.WalkingCost;

    public void SetEnergy(float energy)
    {
        var tempEnergy = this.energy + energy;

        if (tempEnergy < 0)
        {
            this.energy = 0;
            SetHealth(energy);
        }
        else if (tempEnergy < player.Energy)
            this.energy = tempEnergy;
        else
            this.energy = player.Energy;
    }
    #endregion

    #region Hungerness
    private float hungerness;
    private bool isHungry = true;

    public float GetHungerness() => hungerness;
    public float GetHungerCost() => player.HungerCost;
    public bool GetIsHungry() => isHungry;

    public void SetHungeress(float hungerness)
    {
        this.hungerness += hungerness;
        if (this.hungerness >= player.Hungerness)
        {
            this.hungerness = player.Hungerness;
            isHungry = false;
        }
    }

    public void SetIsHungry(bool isHungry)
    {
        if (isHungry) hungerness = 0;
        else hungerness = player.Hungerness;

        this.isHungry = isHungry;
    }


    #endregion

    #region Attack
    public float GetDamage() => player.Damage;
    public float GetAttackSpeed() => player.AttackSpeed;
    public float GetAttackingCost() => player.AttackingCost;
    #endregion

    #region Range
    private float attackRange = 3f;

    public float GetSightRange() => player.SightRange;
    public float GetAttackRange() => attackRange;

    #endregion

}
