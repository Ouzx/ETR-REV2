[System.Serializable]
public class UIPlayer
{
    private float _health;
    public float health
    {
        get { return _health; }
        set
        {
            _health = value;
            UpdatePower();
        }
    }
    public float _energy;
    public float energy
    {
        get { return _energy; }
        set
        {
            _energy = value;
            UpdatePower();
        }
    }
    public float hungerness { get; set; }
    
    public float _speed;
    public float speed
    {
        get { return _speed; }
        set
        {
            _speed = value;
            UpdatePower();
        }
    }
    public float _attackSpeed;
    public float attackSpeed
    {
        get { return _attackSpeed; }
        set
        {
            _attackSpeed = value;
            UpdatePower();
        }
    }
    
    public float _damage;
    public float damage
    {
        get { return _damage; }
        set
        {
            _damage = value;
            UpdatePower();
        }
    }

    public float _sightRange;
    public float sightRange
    {
        get { return _sightRange; }
        set
        {
            _sightRange = value;
            UpdatePower();
        }
    }
    public float healthRegen { get; set; }
    public float energyRegen { get; set; }
    public float walkingCost { get; set; }
    public float attackingCost { get; set; }
    public float hungerCost { get; set; }

    public float power { get; set; }

    private void UpdatePower()
    {
        float oldPower = power;

        power = speed +
                health +
                energy +
                damage +
                attackSpeed +
                sightRange;

        float powerDifference = power / oldPower;

        // STATS
        hungerness *= powerDifference;

        // COSTS
        walkingCost *= powerDifference;
        attackingCost *= powerDifference;
        hungerCost *= powerDifference;
    }

    public void Setter(ICDC.StatType statType, float value)
    {
        switch (statType)
        {
            case ICDC.StatType.Health:
                health = value;
                break;
            case ICDC.StatType.Energy:
                energy = value;
                break;
            case ICDC.StatType.Speed:
                speed = value;
                break;
            case ICDC.StatType.AttackSpeed:
                attackSpeed = value;
                break;
            case ICDC.StatType.Damage:
                damage = value;
                break;
            case ICDC.StatType.SightRange:
                sightRange = value;
                break;
            case ICDC.StatType.HealthRegen:
                healthRegen = value;
                break;
            case ICDC.StatType.EnergyRegen:
                energyRegen = value;
                break;
        }
    }
}
