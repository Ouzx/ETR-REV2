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

    public void Setter(string statType, float value)
    {
        switch (statType)
        {
            case "health":
                health = value;
                break;
            case "energy":
                energy = value;
                break;
            case "speed":
                speed = value;
                break;
            case "ispos":
                attackSpeed = value;
                break;
            case "damage":
                damage = value;
                break;
            case "sightRange":
                sightRange = value;
                break;
            case "healthRegen":
                healthRegen = value;
                break;
            case "energyRegen":
                energyRegen = value;
                break;
                
            default:
                break;
        }
    }
}
