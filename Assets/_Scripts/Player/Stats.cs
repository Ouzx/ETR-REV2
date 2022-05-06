// Oz
using UnityEngine;

public class Stats : MonoBehaviour
{
    public System.Action DoWhenDied;
    public UIPlayer player;

    private void Start()
    {
        name = NameGen.GetName();
        player = GetComponent<Player>().playerType == Player.PlayerType.Player ?
                                                        GameManager.instance.player :
                                                        GameManager.instance.bot;
    }

    #region NAME
    private new string name;

    public string GetName() => name;
    #endregion

    #region Health
    [SerializeField] private float health;

    public float GetHealth() => health;
    public float GetHealthRegen() => player.healthRegen;

    public void SetHealth(float health)
    {
        var tempHealth = health + this.health;
        if (tempHealth < 0)
        {
            this.health = 0;
            DoWhenDied();
        }
        if (tempHealth < player.health)
            this.health = tempHealth;
        else
            this.health = player.health;
    }
    #endregion

    #region Energy
    [SerializeField] private float energy;

    public float GetEnergy() => energy;
    public float GetSpeed() => player.speed;
    public float GetEnergyRegen() => player.energyRegen;
    public float GetWalkingCost() => player.walkingCost;

    public void SetEnergy(float energy)
    {
        var tempEnergy = this.energy + energy;

        if (tempEnergy < 0)
        {
            this.energy = 0;
            SetHealth(energy);
        }
        else if (tempEnergy < player.energy)
            this.energy = tempEnergy;
        else
            this.energy = player.energy;
    }
    #endregion

    #region Hungerness
    [SerializeField] private float hungerness;
    [SerializeField] private bool isHungry;

    public float GetHungerness() => hungerness;
    public float GetHungerCost() => player.hungerCost;
    public bool GetIsHungry() => isHungry;

    public void SetHungeress(float hungerness)
    {
        this.hungerness += hungerness;
        if (this.hungerness >= player.hungerness)
        {
            this.hungerness = player.hungerness;
            isHungry = false;
        }
    }

    public void SetIsHungry(bool isHungry)
    {
        if (isHungry) hungerness = 0;
        else hungerness = player.hungerness;

        this.isHungry = isHungry;
    }


    #endregion

    #region Attack
    public float GetDamage() => player.damage;
    public float GetAttackSpeed() => player.attackSpeed;
    public float GetAttackingCost() => player.attackingCost;
    #endregion

    #region Range
    [SerializeField] private float attackRange;

    public float GetSightRange() => player.sightRange;
    public float GetAttackRange() => attackRange;

    #endregion

}
