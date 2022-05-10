// Oz
using UnityEngine;

public class StatController : MonoBehaviour
{
    [SerializeField] private Stats stats;
    [SerializeField] private Player player;
    [SerializeField] private GameObject FredPrefab, BarneyPrefab;
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
        GameObject PlayerPrefab = player.playerType == Player.PlayerType.Player ? FredPrefab : BarneyPrefab;
        GameObject child = Instantiate(PlayerPrefab, pos, Quaternion.identity, transform.parent);
        child.GetComponent<Player>().stats.SetIsHungry(true);
    }

    private void OnDestroy()
    {
        GameManager.instance.clock.OnTick -= Regen;
    }

}
