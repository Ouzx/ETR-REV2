// Oz
using UnityEngine;

[RequireComponent(typeof(Stats))]
[RequireComponent(typeof(Motor))]
[RequireComponent(typeof(Touch))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(LookAround))]
[RequireComponent(typeof(StateMachine))]
[RequireComponent(typeof(StatController))]
public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        Awake,
        Sleep
    }
    public PlayerState state;
    public Stats stats;

    public void TakeDamage(float damage) => stats.SetHealth(-damage);

    public void Eat(int food) => stats.SetHungeress(food);
}
