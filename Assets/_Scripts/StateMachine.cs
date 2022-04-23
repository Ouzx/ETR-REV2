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

    Animator _animator;
    State _state = State.Idle;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ChangeState(State state)
    {
        if (_state == state)
            return;
        
        _animator.SetBool(_state.ToString(), false);
        Invoke(nameof(doAnimation), .2f);
        _state = state;
    }
    private void doAnimation() => _animator.SetBool(_state.ToString(), true);

    

    public State GetState()
    {
        return _state;
    }
}
