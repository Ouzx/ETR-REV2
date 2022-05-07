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
            health = value;
            UpdatePower();
        }
    }

    [SerializeField] private float energy;
    public float Energy
    {
        get { return energy; }
        set
        {
            energy = value;
            UpdatePower();
        }
    }

    [SerializeField] private float speed;
    public float Speed
    {
        get { return speed; }
        set
        {
            speed = value;
            UpdatePower();
        }
    }

    [SerializeField] private float attackSpeed;
    public float AttackSpeed
    {
        get { return attackSpeed; }
        set
        {
            attackSpeed = value;
            UpdatePower();
        }
    }

    [SerializeField] private float damage;
    public float Damage
    {
        get { return damage; }
        set
        {
            damage = value;
            UpdatePower();
        }
    }

    [SerializeField] private float sightRange;
    public float SightRange
    {
        get { return sightRange; }
        set
        {
            sightRange = value;
            UpdatePower();
        }
    }

    public float HealthRegen;
    public float EnergyRegen;

    public float Hungerness { get; set; }
    public float WalkingCost { get; set; }
    public float AttackingCost { get; set; }
    public float HungerCost { get; set; }

    public float Power { get; set; }
    private void UpdatePower()
    {
        float oldPower = Power;

        Power = Speed +
                Health +
                Energy +
                Damage +
                AttackSpeed +
                SightRange;

        float powerDifference = Power / oldPower;

        // STATS
        Hungerness *= powerDifference;

        // COSTS
        WalkingCost *= powerDifference;
        AttackingCost *= powerDifference;
        HungerCost *= powerDifference;
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
