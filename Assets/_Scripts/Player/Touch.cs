// Oz
using UnityEngine;
public class Touch : MonoBehaviour
{
    private Player player;
    private StateMachine stateMachine;

    private bool isInteracted;
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
        
        if (!isInteracted)
        {
            stateMachine.SetState(StateMachine.State.Attack);
            interactable.transform.GetComponent<Player>().TakeDamage(player.stats.GetDamage());
            GetComponent<StatController>().CastAttack();
            isInteracted = true;
            Invoke(nameof(ResetInteract), player.stats.GetAttackSpeed());
        }
    }

    public void Bite(Interactable interactable)
    {
        if (!isInteracted)
        {
            stateMachine.SetState(StateMachine.State.Eat);
            player.Eat(interactable.transform.GetComponent<Eatable>().GetBite());
            isInteracted = true;
            Invoke(nameof(ResetInteract), player.stats.GetAttackSpeed());
        }
    }

    // If I am stronger; return true;
    public bool ComparePowers(Transform _enemy) => player.stats.GetPower() > _enemy.GetComponent<Player>().stats.GetPower();

    void ResetInteract() => isInteracted = false;
}
