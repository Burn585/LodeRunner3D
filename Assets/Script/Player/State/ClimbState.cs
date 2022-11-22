using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClimbState : State
{
    public event UnityAction<string> StartVerticalMove;
    public event UnityAction<bool> PauseAnimation;

    private float _verticalMove;
    private float _horizontalMove;

    public ClimbState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //Debug.Log("Enter climb state");

        StartVerticalMove?.Invoke("Climb");
        _character._rigidbody.position = new Vector3(_character.StairPosition.x + 0.8f, _character._rigidbody.position.y, _character._rigidbody.position.z);
    }

    public override void HandleInput()
    {
        base.HandleInput();
        _verticalMove = Input.GetAxis("Vertical");
        _horizontalMove = Input.GetAxis("Horizontal");
    }

    public override void Transition()
    {
        base.Transition();

        if(_horizontalMove != 0 && _character.IsMoveStair)
        {
            _stateMachine.ChangeState(_character.RunState);
        }

        if(_verticalMove != 0 && !_character.IsMoveStair)
        {
            _stateMachine.ChangeState(_character.IdleState);
        }

        //Die
        //Crawl
        //Win
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        _character._rigidbody.useGravity = false;
        _character._rigidbody.position += new Vector3(0, _verticalMove, 0) * _character.MovementSpeed * Time.deltaTime;

        if(_verticalMove == 0)
        {
            PauseAnimation?.Invoke(true);
        }
        else
        {
            PauseAnimation?.Invoke(false);
        }
    }

    public override void Exit()
    {
        base.Exit();
        PauseAnimation?.Invoke(false);
    }
}