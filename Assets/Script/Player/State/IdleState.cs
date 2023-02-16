using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IdleState : State
{
    public event UnityAction<string> StartStateIdle;

    private float _horizontalMove;
    private float _verticalMove;

    public IdleState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //Debug.Log("Enter idle state");

        StartStateIdle?.Invoke(AnimatorPlayer.States.Idle);
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

        if(_horizontalMove != 0)
        {
            _stateMachine.ChangeState(_character.RunState);
        }

        if(_verticalMove != 0 && _character.IsMoveStair)
        {
            _stateMachine.ChangeState(_character.ClimbState);
        }

        //Crawl
        //Die
        //Attack
    }
}
