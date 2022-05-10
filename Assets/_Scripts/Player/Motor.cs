// Oz
using System.Collections;
using UnityEngine;

public class Motor : MonoBehaviour
{
    [SerializeField] private StatController statController;
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private LookAround lookAround;
    [SerializeField] private Movement movement;
    [SerializeField] private Player player;
    [SerializeField] private Touch touch;

    System.Action DoWhenAtBase;

    private void Start()
    {
        player.stats.DoWhenDied += Die;

        GameManager.instance.clock.OnDawn += OnDawn;
        GameManager.instance.clock.OnSunset += Sleep;
        GameManager.instance.Print(player.name, "Player created");
        StartCoroutine(Decide());
    }
    public IEnumerator Decide()
    {
        while (true)
        {
            GameManager.instance.Print(player.name,"Player State: " + player.state);
            if (player.state == Player.PlayerState.Awake)
            {
                Interactable target = lookAround.Search();
                bool isArrived = movement.Walk(target.Position);

                if (target.type == Interactable.Type.ToBase)
                {
                    GameManager.instance.Print(player.name, "I headed to base");
                    if (isArrived)
                    {
                        GameManager.instance.Print(player.name, "I arrived at base");
                        stateMachine.SetState(StateMachine.State.Idle);
                        if (DoWhenAtBase != null)
                        {
                            DoWhenAtBase();
                            DoWhenAtBase = null;
                        }

                    }
                }
                else if (isArrived)
                {
                    GameManager.instance.Print(player.name, "I arrived my interaction: " + target.Position); 
                    touch.Interact(target);
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }
    
    public void OnDawn()
    {
        if (movement.WhereAmI() == Movement.Locations.Base)
        {
            if (!player.stats.GetIsHungry())
            {
                GameManager.instance.Print(player.name, "I ate something yesterday, I'll reproduce today.");
                statController.Reproduce(lookAround.GetRandomBasePoint());
            }
            player.stats.SetIsHungry(true);
            stateMachine.SetState(StateMachine.State.Idle);
            player.state = Player.PlayerState.Awake;
            GameManager.instance.Earn();
        }
    }

    public void OnSunset()
    {
        if (movement.WhereAmI() == Movement.Locations.Wilderness)
        {
            DoWhenAtBase += Sleep;
        }
        else Sleep();
    }

    public void Sleep()
    {
        GameManager.instance.Print(player.name, "I'm sleeping");
        player.state = Player.PlayerState.Sleep;
        stateMachine.SetState(StateMachine.State.Sleep);

        if (DoWhenAtBase != null)
            DoWhenAtBase -= Sleep;
    }

    private void Die()
    {
        GameManager.instance.Print(player.name, "I died");
        StopCoroutine(Decide());

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
