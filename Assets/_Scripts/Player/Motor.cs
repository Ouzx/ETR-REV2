// Oz
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Motor : MonoBehaviour
{
    private StateMachine stateMachine;
    private LookAround lookAround;
    private Movement movement;
    private Player player;
    
    private void Start()
    {
        player = GetComponent<Player>();
        movement = GetComponent<Movement>();
        lookAround = GetComponent<LookAround>();
        stateMachine = GetComponent<StateMachine>();
    }

    public void Decide()
    {
        switch (stateMachine.GetState())
        {
            case StateMachine.State.Idle:
                // day ? walk : sleep
                Idle();
                break;
            case StateMachine.State.Walk:
                // Find something
                Walk();
                break;
            case StateMachine.State.Attack:
                // Check opponent
                Attack();
                break;
            case StateMachine.State.Eat:
                // Check food
                Eat();
                break;
            case StateMachine.State.Sleep:
                // Wait until morning
                Sleep();
                break;
            case StateMachine.State.Death:
                // destroy
                Death();
                break;
        }
    }

    private void Idle()
    {
        if (Clock.dayState == Clock.DayState.Day)
        {
            // Look for food
            if (player.stats.GetIsHungry())
            {
                Vector3 movePoint = lookAround.Search();
            }
            else
            {
                
            }
        }
        else if (Clock.dayState == Clock.DayState.Night)
        {
            // Go base
        }
    }

    private void Walk()
    {
        // 
    }

    private void Attack()
    {

    }

    private void Eat()
    {

    }

    private void Sleep()
    {

    }

    private void Death()
    {
        Destroy(gameObject);
    }


}
