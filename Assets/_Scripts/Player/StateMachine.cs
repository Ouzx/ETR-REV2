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

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetState(State _state)
    {
        void doAnimation() => animator.SetBool(state.ToString(), true);
        
        if (state == _state)
            return;

        animator.SetBool(state.ToString(), false);
        state = _state;
        Invoke(nameof(doAnimation), .2f);
        
    }

    public State GetState() => state;
    
}
