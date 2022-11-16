using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallState : State
{
    public event UnityAction<string> StartStateFall;

    public FallState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StartStateFall?.Invoke("Fall");
    }

    public override void Transition()
    {
        base.Transition();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
