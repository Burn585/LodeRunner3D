using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallState : State
{
    public event UnityAction<string> StartStateFall;
    public event UnityAction<string> EndStateFall;

    private float _horizontalMove;
    private float _verticalMove;

    public FallState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StartStateFall?.Invoke(AnimatorPlayer.States.Fall);
    }

    public override void HandleInput()
    {
        base.HandleInput();

        _horizontalMove = Input.GetAxis("Horizontal");
        _verticalMove = Input.GetAxis("Vertical");
    }

    public override void Transition()
    {
        base.Transition();

        if (_character.IsGrounded)
        {
            _stateMachine.ChangeState(_character.IdleState);
        }

        if (_character.IsMoveStair)
        {
            _stateMachine.ChangeState(_character.ClimbState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        EndStateFall?.Invoke(AnimatorPlayer.States.Fall);
    }
}
