// Oz
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerMotor motor;
    StateMachine stateMachine;
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.instance;
        
        motor = GetComponent<PlayerMotor>();
        stateMachine = GetComponent<StateMachine>();
    }

    private void Update()
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
        if(gameManager.clock.dayState == Clock.DayState.Day)
        {
            
        }
        else if (gameManager.clock.dayState == Clock.DayState.Night)
        {
        
        }
    }

    private void Walk()
    {
  
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
