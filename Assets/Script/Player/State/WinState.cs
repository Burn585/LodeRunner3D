using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinState : State
{
    public event UnityAction<string> StartStateWin;
    public event UnityAction<float> EndStateWin;

    private float _delayReboot = 13;

    public WinState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartStateWin?.Invoke(AnimatorPlayer.States.Win);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        EndStateWin?.Invoke(_delayReboot);

    }
}
