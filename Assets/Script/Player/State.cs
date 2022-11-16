using UnityEngine;

public abstract class State
{
    protected Character _character;
    protected StateMachine _stateMachine;

    protected State(Character character, StateMachine stateMachine)
    {
        _character = character;
        _stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
    }

    public virtual void HandleInput()
    {
    }

    public virtual void Transition()
    {
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void Exit()
    {
    }
}
