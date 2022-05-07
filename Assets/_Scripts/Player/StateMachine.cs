// Oz
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        Idle,
        Walk,
        Attack,
        Sleep,
        Eat,
        Death
    }
    private State state = State.Idle;

    [SerializeField] Animator animator;

    public void SetState(State _state)
    {        
        if (state == _state)
            return;

        animator.SetBool(state.ToString(), false);
        state = _state;
        Invoke(nameof(doAnimation), .2f);
        
    }
    void doAnimation() => animator.SetBool(state.ToString(), true);
    public State GetState() => state;
    
}
