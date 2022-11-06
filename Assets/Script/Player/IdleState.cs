using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IdleState : State
{
    public event UnityAction<string> StartHorizontalMove;
    public event UnityAction<string> StartVerticalMove;

    private float _horizontalMove;
    private float _verticalMove;

    public IdleState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Enter idle state");
    }

    public override void HandleInput()
    {
        base.HandleInput();

        _horizontalMove = Input.GetAxis("Horizontal");
        _verticalMove = Input.GetAxis("Vertical");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(_horizontalMove != 0)
        {
            _stateMachine.ChangeState(_character.MovingState);
            StartHorizontalMove?.Invoke("Run");
        }

        if(_verticalMove != 0)
        {
            _stateMachine.ChangeState(_character.MovingState);
            StartVerticalMove?.Invoke("Run");
        }
    }
}
