// Oz
using UnityEngine;
public class Touch : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private StateMachine stateMachine;

    private bool isInteracted;

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
        //GameManager.instance.Print(player.name, "I'm attacking " + interactable.transform.name);
        if (!isInteracted)
        {
            stateMachine.SetState(StateMachine.State.Attack);
            interactable.transform.GetComponent<Player>().TakeDamage(player.stats.GetDamage());
            GetComponent<StatController>().CastAttack();
            isInteracted = true;
            Invoke(nameof(ResetInteract), player.stats.GetAttackSpeed()); // Animation does not react attack speed but backend does react attack speed
        }
    }

    public void Bite(Interactable interactable)
    {
        //GameManager.instance.Print(player.name, "I'm biting " + interactable.transform.name);
        if (!isInteracted)
        {
            stateMachine.SetState(StateMachine.State.Eat);
            player.Eat(interactable.transform.GetComponent<Eatable>().GetBite());
            isInteracted = true;
            Invoke(nameof(ResetInteract), 1000 / (player.stats.GetAttackSpeed() * 1000));
        }
    }

    // If I am stronger; return true;
    public bool ComparePowers(Transform _enemy) => player.stats.GetPower() > _enemy.GetComponent<Player>().stats.GetPower();

    void ResetInteract()
    {
        isInteracted = false;
    }
}
