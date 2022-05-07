// Oz
using UnityEngine;

public class StatController : MonoBehaviour
{
    [SerializeField] private Stats stats;

    private void Start()
    {
        GameManager.instance.clock.OnTick += Regen;
    }

    public void Regen()
    {
        if (!stats.GetIsHungry())
        {
            stats.SetHealth(stats.GetHealthRegen());
            stats.SetEnergy(stats.GetEnergyRegen());
        }
        else
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
    }

}
