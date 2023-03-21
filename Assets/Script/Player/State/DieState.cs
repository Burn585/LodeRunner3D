using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DieState : State
{
    public event UnityAction<string> StartStateDie;
    public event UnityAction EndStateDie;

    public DieState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StartStateDie?.Invoke(AnimatorPlayer.States.Die);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        EndStateDie?.Invoke();
    }
}
