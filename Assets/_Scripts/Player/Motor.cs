// Oz
using System.Collections;
using UnityEngine;

public class Motor : MonoBehaviour
{
    private StatController statController;
    private StateMachine stateMachine;
    private LookAround lookAround;
    private Movement movement;
    private Player player;
    private Touch touch;

    private void Start()
    {
        touch = GetComponent<Touch>();
        player = GetComponent<Player>();
        movement = GetComponent<Movement>();
        lookAround = GetComponent<LookAround>();
        stateMachine = GetComponent<StateMachine>();

        player.stats.DoWhenDied += Die;

        GameManager.instance.clock.OnDawn += OnDawn;
        GameManager.instance.clock.OnSunset += Sleep;      

        StartCoroutine(Decide());
    }
    public IEnumerator Decide()
    {
        while (true)
        {
            while (player.state == Player.PlayerState.Awake)
            {
                Interactable target = lookAround.Search();
                bool isArrived = movement.Walk(target.position);

                if (target.type == Interactable.Type.ToBase)
                {
                    if (isArrived)
                        stateMachine.SetState(StateMachine.State.Idle);
                }
                else if (isArrived)
                    touch.Interact(target);
                yield return new WaitForEndOfFrame();
            }
            yield return null;
        }
    }
    public void OnDawn()
    {
        if(movement.WhereAmI() == Movement.Locations.Base){
            if (!player.stats.GetIsHungry())
            {
                statController.Reproduce(lookAround.GetRandomBasePoint());
            }
            player.stats.SetIsHungry(true);
            stateMachine.SetState(StateMachine.State.Idle);
            player.state = Player.PlayerState.Awake;
            GameManager.instance.EarnEP();
        }
    }

    public void OnSunset()
    {
        if (movement.WhereAmI() == Movement.Locations.Wilderness)
        {
            movement.DoWhenAtBase += Sleep;
        }
        else Sleep();
    }

    public void Sleep()
    {
        player.state = Player.PlayerState.Sleep;
        stateMachine.SetState(StateMachine.State.Sleep);

        if (movement.DoWhenAtBase != null)
            movement.DoWhenAtBase -= Sleep;
    }

    private void Die()
    {
        stateMachine.SetState(StateMachine.State.Death);
        
        void DestroySelf() => Destroy(gameObject);

        Invoke(nameof(DestroySelf), 5f);
    }

    

    private void OnDestroy()
    {
        GameManager.instance.clock.OnDawn -= OnDawn;
        GameManager.instance.clock.OnSunset -= OnSunset;      
    }

}
