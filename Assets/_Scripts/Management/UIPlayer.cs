[System.Serializable]
public class UIPlayer
{
    public float health
    {
        get { return health; }
        set
        {
            health = value;
            UpdatePower();
        }
    }
    public float energy
    {
        get { return energy; }
        set
        {
            energy = value;
            UpdatePower();
        }
    }
    public float hungerness { get; set; }
    public float speed
    {
        get { return speed; }
        set
        {
            speed = value;
            UpdatePower();
        }
    }
    public float attackSpeed
    {
        get { return attackSpeed; }
        set
        {
            attackSpeed = value;
            UpdatePower();
        }
    }
    public float damage
    {
        get { return damage; }
        set
        {
            damage = value;
            UpdatePower();
        }
    }
    public float sightRange
    {
        get { return sightRange; }
        set
        {
            sightRange = value;
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


}
