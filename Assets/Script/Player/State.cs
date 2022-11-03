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
        Debug.Log("State Enter");
    }

    public virtual void HandleInput()
    {
        Debug.Log("State Handle");
    }

    public virtual void LogicUpdate()
    {
        Debug.Log("State Logic");
    }

    public virtual void PhysicsUpdate()
    {
        Debug.Log("State Physics");
    }

    public virtual void Exit()
    {
        Debug.Log("State Exit");
    }
}
