// Oz
using UnityEngine;

[RequireComponent(typeof(Stats))]
[RequireComponent(typeof(Motor))]
[RequireComponent(typeof(Touch))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(LookAround))]
[RequireComponent(typeof(StateMachine))]
public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        Awake,
        Sleep
    }
    public PlayerState state;


    public Stats stats;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public void GetTired(float Distance)
    {

    }

    public void TakeDamage(float damge)
    {

    }

    public void Eat(int food)
    {

    }
    private void Regen()
    {
        if (!stats.GetIsHungry()) return;

        HealthRegen();
        EnergyRegen();
    }

    private void HealthRegen()
    {
        if (stats.GetHealth() >= stats.GetMaxHealth()) return;

        stats.SetHealth(stats.GetHealth() + stats.GetHealthRegen());
    }

    private void EnergyRegen()
    {
        if (stats.GetEnergy() >= stats.GetMaxEnergy()) return;

        stats.SetEnergy(stats.GetEnergy() + stats.GetEnergyRegen());
    }

    public void Reproduce()
    {

    }
}
