// Oz
using UnityEngine;

public class Motor : MonoBehaviour
{
    private StateMachine stateMachine;
    private GameManager gameManager;
    private LookAround lookAround;
    private Movement movement;
    private Player player;
    private Attack attack;

    private void Start()
    {
        player = GetComponent<Player>();
        movement = GetComponent<Movement>();
        lookAround = GetComponent<LookAround>();
        stateMachine = GetComponent<StateMachine>();
    
        gameManager = GameManager.instance;

        gameManager.clock.OnDawn += OnDawn;
        gameManager.clock.OnSunset += Sleep;
    }
    public void Decide()
    {
        while (player.state == Player.PlayerState.Awake)
        {
            // Look for food
            if (player.stats.GetIsHungry())
            {
                Interactable target = lookAround.Search();
                bool isArrived = movement.Walk(target.position);

                if (isArrived)
                {
                    attack.Interact(target);
                }
            }
            else
            {
                Vector3 basePoint = lookAround.GetRandomBasePoint();

                bool isArrived = movement.Walk(basePoint);

                if (isArrived)
                {
                    stateMachine.SetState(StateMachine.State.Idle);
                }
            }
        }
    }
    public void OnDawn()
    {
        if (!player.stats.GetIsHungry())
        {
            player.Reproduce();
        }
        
        player.stats.SetIsHungry(true);
        stateMachine.SetState(StateMachine.State.Idle);
        player.state = Player.PlayerState.Awake;
    }

    public void OnSunset()
    {
        if(movement.WhereAmI() == Movement.Locations.Wilderness)
        {
            movement.DoWhenAtBase += Sleep;
        }
        else Sleep();
    }

    public void Sleep()
    {
        player.state = Player.PlayerState.Sleep;
        stateMachine.SetState(StateMachine.State.Sleep);
    }

    private void OnDestroy()
    {
        gameManager.clock.OnDawn -= OnDawn;
        gameManager.clock.OnSunset -= OnSunset;
    }

}
