// Oz
using UnityEngine;

public class Stats : MonoBehaviour
{
    public System.Action DoWhenDied;

    private void Start() => name = NameGen.GetName();

    #region NAME
    private new string name;

    public string GetName() => name;
    #endregion

    #region Power
    [SerializeField] private float power;

    public float GetPower() => power;

    private void UpdatePower()
    {
        float oldPower = power;

        power = GetSpeed() +
                GetMaxHealth() +
                GetMaxEnergy() +
                GetDamage() +
                GetAttackSpeed() +
                GetAttackRange() +
                GetSightRange();

        float powerDifference = power / oldPower;

        // STATS
        maxHunger *= powerDifference;

        // COSTS
        walkingCost *= powerDifference;
        attackingCost *= powerDifference;
        hungerCost *= powerDifference;

        transform.localScale = Vector3.one * powerDifference;
    }

    #endregion

    #region Health
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float healthRegen;

    public float GetHealth() => health;
    public float GetMaxHealth() => maxHealth;
    public float GetHealthRegen() => healthRegen;

    public void SetHealth(float health)
    {
        var tempHealth = health + this.health;
        if (tempHealth < 0)
        {
            this.health = 0;
            DoWhenDied();
        }
        if (tempHealth < maxHealth)
            this.health = tempHealth;
        else
            this.health = maxHealth;
    }

    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
        UpdatePower();
    }

    public void SetHealthRegen(float healthRegen)
    {
        this.healthRegen = healthRegen;
    }

    #endregion

    #region Energy
    [SerializeField] private float energy;
    [SerializeField] private float maxEnergy;
    [SerializeField] private float energyRegen;
    [SerializeField] private float walkingCost;

    public float GetEnergy() => energy;
    public float GetMaxEnergy() => maxEnergy;
    public float GetEnergyRegen() => energyRegen;
    public float GetWalkingCost() => walkingCost;

    public void SetEnergy(float energy)
    {
        var tempEnergy = this.energy + energy;

        if (tempEnergy < 0)
        {
            this.energy = 0;
            SetHealth(energy);
        }
        else if (tempEnergy < maxEnergy)
            this.energy = tempEnergy;
        else if (tempEnergy > maxEnergy)
            this.energy = maxEnergy;
    }

    public void SetMaxEnergy(float maxEnergy)
    {
        this.maxEnergy = maxEnergy;
        UpdatePower();
    }

    public void SetEnergyRegen(float energyRegen)
    {
        this.energyRegen = energyRegen;
    }

    #endregion

    #region Hungerness
    [SerializeField] private float hungerness;
    [SerializeField] private float maxHunger;
    [SerializeField] private float hungerCost;
    [SerializeField] private bool isHungry;

    public float GetHungerness() => hungerness;
    public float GetHungerCost() => hungerCost;
    public bool GetIsHungry() => isHungry;

    public void SetHungeress(float hungerness)
    {
        this.hungerness += hungerness;
        if (this.hungerness >= maxHunger)
        {
            this.hungerness = maxHunger;
            isHungry = false;
        }
    }

    public void SetIsHungry(bool isHungry)
    {
        if (isHungry) hungerness = 0;
        else hungerness = maxHunger;

        this.isHungry = isHungry;
    }


    #endregion

    #region Speed
    [SerializeField] private float speed;

    public float GetSpeed() => speed;

    public void SetSpeed(float speed)
    {
        this.speed = speed;
        GetComponent<UnityEngine.AI.NavMeshAgent>().acceleration = speed; // TODO: SPEED OR ACCELERATION?
        UpdatePower();
    }
    #endregion

    #region Attack
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackingCost;

    public float GetDamage() => damage;
    public float GetAttackSpeed() => attackSpeed;
    public float GetAttackingCost() => attackingCost;

    public void SetDamage(float damage)
    {
        this.damage = damage;
        UpdatePower();
    }

    public void SetAttackSpeed(float attackSpeed)
    {
        this.attackSpeed = attackSpeed;
        UpdatePower();
    }

    #endregion

    #region Range
    [SerializeField] private float sightRange;
    [SerializeField] private float attackRange;

    public float GetSightRange() => sightRange;
    public float GetAttackRange() => attackRange;

    public void SetSightRange(float sightRange)
    {
        this.sightRange = sightRange;
        UpdatePower();
    }
    #endregion

}
