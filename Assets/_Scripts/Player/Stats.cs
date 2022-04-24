// Oz
using UnityEngine;
public class Stats : MonoBehaviour
{
    public void UpdateStats()
    {
        
    }

    [SerializeField] private new string name;

    [SerializeField] private float power;
    [SerializeField] private float health;
    [SerializeField] private float energy;
    [SerializeField] private float hunger;
    [SerializeField] private bool isHungry;

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;

    [SerializeField] private float sightRange;
    [SerializeField] private float walkPointRange;
    [SerializeField] private float attackRange;

    [SerializeField] private float healthRegen;
    [SerializeField] private float energyRegen;

    [SerializeField] private float hungerCost;
    [SerializeField] private float walkingCost;
    [SerializeField] private float attackingCost;

    [SerializeField] private float nightCost;

    [SerializeField] private int childCount;
    [SerializeField] private int generation;
    [SerializeField] private int age;
    [SerializeField] private int birthDay;
    [SerializeField] private int kills;

    #region Getters and Setters
    public string GetName() => name;

    public float GetPower() => power;

    public float GetHealth() => health;

    public float GetEnergy() => energy;

    public float GetHunger() => hunger;

    public bool GetIsHungry() => isHungry;

    public float GetSpeed() => speed;

    public float GetDamage() => damage;

    public float GetAttackSpeed() => attackSpeed;

    public float GetSightRange() => sightRange;

    public float GetWalkPointRange() => walkPointRange;

    public float GetAttackRange() => attackRange;

    public float GetHealthRegen() => healthRegen;

    public float GetEnergyRegen() => energyRegen;

    public float GetHungerCost() => hungerCost;

    public float GetWalkingCost() => walkingCost;

    public float GetAttackingCost() => attackingCost;

    public float GetNightCost() => nightCost;

    public int GetChildCount() => childCount;

    public int GetGeneration() => generation;

    public int GetAge() => age;

    public int GetBirthDay() => birthDay;

    public int GetKills() => kills;

    public void SetName(string name) => this.name = name;

    public void SetPower(float power)
    {
        this.power = power;
        UpdateStats();
    }

    public void SetHealth(float health)
    {
        this.health = health;
        UpdateStats();
    }

    public void SetEnergy(float energy)
    {
        this.energy = energy;
        UpdateStats();
    }

    public void SetHunger(float hunger)
    {
        this.hunger = hunger;
        UpdateStats();
    }

    public void SetIsHungry(bool isHungry)
    {
        this.isHungry = isHungry;
        UpdateStats();
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
        UpdateStats();
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
        UpdateStats();
    }

    public void SetAttackSpeed(float attackSpeed)
    {
        this.attackSpeed = attackSpeed;
        UpdateStats();
    }

    public void SetSightRange(float sightRange)
    {
        this.sightRange = sightRange;
        UpdateStats();
    }

    public void SetWalkPointRange(float walkPointRange)
    {
        this.walkPointRange = walkPointRange;
        UpdateStats();
    }

    public void SetAttackRange(float attackRange)
    {
        this.attackRange = attackRange;
        UpdateStats();
    }

    public void SetHealthRegen(float healthRegen)
    {
        this.healthRegen = healthRegen;
        UpdateStats();
    }

    public void SetEnergyRegen(float energyRegen)
    {
        this.energyRegen = energyRegen;
        UpdateStats();
    }

    public void SetHungerCost(float hungerCost)
    {
        this.hungerCost = hungerCost;
        UpdateStats();
    }

    public void SetWalkingCost(float walkingCost)
    {
        this.walkingCost = walkingCost;
        UpdateStats();
    }

    public void SetAttackingCost(float attackingCost)
    {
        this.attackingCost = attackingCost;
        UpdateStats();
    }

    public void SetNightCost(float nightCost)
    {
        this.nightCost = nightCost;
        UpdateStats();
    }

    public void SetChildCount(int childCount)
    {
        this.childCount = childCount;
        UpdateStats();
    }

    public void SetGeneration(int generation)
    {
        this.generation = generation;
        UpdateStats();
    }

    public void SetAge(int age)
    {
        this.age = age;
        UpdateStats();
    }

    public void SetBirthDay(int birthDay)
    {
        this.birthDay = birthDay;
        UpdateStats();
    }

    public void SetKills(int kills)
    {
        this.kills = kills;
        UpdateStats();
    }
    #endregion

}
