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

        StartCoroutine(Decide());
    }
    public IEnumerator Decide()
    {
        while (true)
        {
            if (player.state == Player.PlayerState.Awake)
            {
                Interactable target = lookAround.Search();
                bool isArrived = movement.Walk(target.Position);

                if (target.type == Interactable.Type.ToBase)
                {
                    if (isArrived)
                    {
                        stateMachine.SetState(StateMachine.State.Idle);
                        if (DoWhenAtBase != null)
                        {
                            DoWhenAtBase();
                            DoWhenAtBase = null;
                        }

                    }
                }
                else if (isArrived)
                    touch.Interact(target);

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
        player.state = Player.PlayerState.Sleep;
        stateMachine.SetState(StateMachine.State.Sleep);

        if (DoWhenAtBase != null)
            DoWhenAtBase -= Sleep;
    }

    private void Die()
    {
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
