// Oz
using UnityEngine;
public class Stats : MonoBehaviour
{
    #region NAME
    private new string name;
    
    public string GetName() => name;

    public void SetName(string name) => this.name = name;
    #endregion

    #region Power
    [SerializeField] private float power;

    public float GetPower() => power;

    private void UpdatePower()
    {
        // power calc is here
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
        this.health = health;
        UpdatePower();
    }

    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
        UpdatePower();
    }
    
    public void SetHealthRegen(float healthRegen)
    {
        this.healthRegen = healthRegen;
        UpdatePower();
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
        this.energy = energy;
        UpdatePower();
    }

    public void SetMaxEnergy(float maxEnergy)
    {
        this.maxEnergy = maxEnergy;
        UpdatePower();
    }

    public void SetEnergyRegen(float energyRegen)
    {
        this.energyRegen = energyRegen;
        UpdatePower();
    }

    public void SetWalkingCost(float walkingCost)
    {
        this.walkingCost = walkingCost;
        UpdatePower();
    }

    #endregion

    #region Hungerness
    [SerializeField] private float hunger;
    [SerializeField] private float maxHunger;
    [SerializeField] private bool isHungry;
    [SerializeField] private float hungerCost;

    public float GetHunger() => hunger;
    public float GetMaxHunger() => maxHunger;
    public bool GetIsHungry() => isHungry;
    public float GetHungerCost() => hungerCost;
    
    public void SetHunger(float hunger)
    {
        this.hunger = hunger;
        UpdatePower();
    }

    public void SetMaxHunger(float maxHunger)
    {
        this.maxHunger = maxHunger;
        UpdatePower();
    }

    public void SetIsHungry(bool isHungry)
    {
        this.isHungry = isHungry;
        UpdatePower();
    }

    public void SetHungerCost(float hungerCost)
    {
        this.hungerCost = hungerCost;
        UpdatePower();
    }

    #endregion

    #region Speed
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;

    public float GetSpeed() => speed;
    public float GetMaxSpeed() => maxSpeed;

    public void SetSpeed(float speed)
    {
        this.speed = speed;
        UpdatePower();
    }

    public void SetMaxSpeed(float maxSpeed)
    {
        this.maxSpeed = maxSpeed;
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

    public void SetAttackingCost(float attackingCost)
    {
        this.attackingCost = attackingCost;
        UpdatePower();
    }

    #endregion

    #region Range
    [SerializeField] private float sightRange;
    [SerializeField] private float walkPointRange;
    [SerializeField] private float attackRange;

    public float GetSightRange() => sightRange;
    public float GetWalkPointRange() => walkPointRange;
    public float GetAttackRange() => attackRange;

    public void SetSightRange(float sightRange)
    {
        this.sightRange = sightRange;
        UpdatePower();
    }

    public void SetWalkPointRange(float walkPointRange)
    {
        this.walkPointRange = walkPointRange;
        UpdatePower();
    }

    public void SetAttackRange(float attackRange)
    {
        this.attackRange = attackRange;
        UpdatePower();
    }
    #endregion
    
}
