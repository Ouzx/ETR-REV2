using UnityEngine;
[System.Serializable]
public class UIPlayer
{
    [SerializeField] private float health;
    public float Health
    {
        get { return health; }
        set
        {
            if (health + value > 0)
                health += value;
            UpdatePower();
        }
    }

    [SerializeField] private float energy;
    public float Energy
    {
        get { return energy; }
        set
        {
            if (energy + value > 0)
                energy += value;
            UpdatePower();
        }
    }

    [SerializeField] private float speed;
    public float Speed
    {
        get { return speed; }
        set
        {
            if (speed + value > 0)
                speed += value;
            UpdatePower();
        }
    }

    [SerializeField] private float attackSpeed;
    public float AttackSpeed
    {
        get { return attackSpeed; }
        set
        {
            if (attackSpeed + value > 0)
                attackSpeed += value;
            UpdatePower();
        }
    }

    [SerializeField] private float damage;
    public float Damage
    {
        get { return damage; }
        set
        {
            if (damage + value > 0)
                damage += value;
            UpdatePower();
        }
    }

    [SerializeField] private float sightRange;
    public float SightRange
    {
        get { return sightRange; }
        set
        {
            if (sightRange + value > 0)
                sightRange += value;
            UpdatePower();
        }
    }
    [SerializeField] private float healthRegen;
    public float HealthRegen
    {
        get { return healthRegen; }
        set
        {
            if (healthRegen + value > 0)
                healthRegen += value;
            UpdatePower();
        }
    }
    [SerializeField] private float energyRegen;
    public float EnergyRegen
    {
        get { return energyRegen; }
        set
        {
            if (energyRegen + value > 0)
                energyRegen += value;
            UpdatePower();
        }
    }

    [SerializeField] private float hungerness;
    public float Hungerness { get { return hungerness; } set { hungerness = value; } }

    [SerializeField] private float walkingCost;
    public float WalkingCost { get { return walkingCost; } set { walkingCost = value; } }

    [SerializeField] private float attackingCost;
    public float AttackingCost { get { return attackingCost; } set { attackingCost = value; } }

    [SerializeField] private float hungerCost;
    public float HungerCost { get { return hungerCost; } set { hungerCost = value; } }

    public float Power { get; set; }
    public void UpdatePower()
    {
        float oldPower = Power;

        Power = Speed +
                Health +
                Energy +
                Damage +
                AttackSpeed +
                SightRange;

        //float powerDifference = Power / oldPower;
        //if (powerDifference != 0)
        //{
        //    // STATS
        //    Hungerness *= powerDifference;

        //    // COSTS
        //    WalkingCost *= powerDifference;
        //    AttackingCost *= powerDifference;
        //    HungerCost *= powerDifference;
        //}
    }

    public void Setter(ICDC.StatType statType, float value)
    {
        switch (statType)
        {
            case ICDC.StatType.Health:
                Health = value;
                break;
            case ICDC.StatType.Energy:
                Energy = value;
                break;
            case ICDC.StatType.Speed:
                Speed = value;
                break;
            case ICDC.StatType.AttackSpeed:
                AttackSpeed = value;
                break;
            case ICDC.StatType.Damage:
                Damage = value;
                break;
            case ICDC.StatType.SightRange:
                SightRange = value;
                break;
            case ICDC.StatType.HealthRegen:
                HealthRegen = value;
                break;
            case ICDC.StatType.EnergyRegen:
                EnergyRegen = value;
                break;
        }
    }
}
