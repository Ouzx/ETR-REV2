// Oz
using UnityEngine;
public class Touch : MonoBehaviour
{
    private Player player;
    private StateMachine stateMachine;
    private void Start()
    {
        player = GetComponent<Player>();
        stateMachine = GetComponent<StateMachine>();
    }

    public void Interact(Interactable interactable)
    {
        switch (interactable.type)
        {
            case Interactable.Type.Enemy:
                AttackEnemy(interactable);
                break;
            case Interactable.Type.Food:
                Bite(interactable);
                break;
            default:
                break;
        }
    }

    public void AttackEnemy(Interactable interactable)
    {
        stateMachine.SetState(StateMachine.State.Attack);
        interactable.transform.GetComponent<Player>().TakeDamage(player.stats.GetDamage());
        GetComponent<StatController>().CastAttack();
        System.Threading.Thread.Sleep(ISPOS());
    }

    public void Bite(Interactable interactable)
    {
        stateMachine.SetState(StateMachine.State.Eat);
        player.Eat(interactable.transform.GetComponent<Eatable>().GetBite());
        System.Threading.Thread.Sleep(ISPOS());
    }

    // interaction speed per second
    private int ISPOS() => (int)(1000 / player.stats.GetAttackSpeed() * 1000);


    // If I am stronger; return true;
    public bool ComparePowers(Transform _enemy) => player.stats.GetPower() > _enemy.GetComponent<Player>().stats.GetPower();
}
