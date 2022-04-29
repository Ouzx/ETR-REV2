// Oz
using UnityEngine;

public class StatController : MonoBehaviour
{
    private Stats stats;

    private void Start()
    {
        stats = GetComponent<Stats>();

        GameManager.instance.clock.OnTick += Regen;
        GameManager.instance.clock.OnTick += Starve;
    }

    public void Regen()
    {
        if (!stats.GetIsHungry())
        {
            stats.SetHealth(stats.GetHealthRegen());
            stats.SetEnergy(stats.GetEnergyRegen());
        }
    }

    public void Starve()
    {
        if (stats.GetIsHungry())
            stats.SetEnergy(-stats.GetHungerCost());
    }

    public void CastWalking(float distance) => stats.SetEnergy(-stats.GetWalkingCost() * distance);
    public void CastAttack() => stats.SetEnergy(-stats.GetAttackingCost());

    public void Reproduce(Vector3 pos)
    {
        GameObject child = Instantiate(gameObject, pos, Quaternion.identity, transform.parent);
        child.GetComponent<Player>().stats.SetIsHungry(true);
    }

    private void OnDestroy()
    {
        GameManager.instance.clock.OnTick -= Regen;
        GameManager.instance.clock.OnTick -= Starve;
    }

}
