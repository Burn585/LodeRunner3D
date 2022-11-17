using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunState : State
{
    public event UnityAction<float> ChangeDirection;
    public event UnityAction<string> StartStateRun;

    private float _horizontalMove;
    private float _verticalMove;

    public RunState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //Debug.Log("Enter moving state");

        StartStateRun?.Invoke("Run");
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

        if (_horizontalMove == 0)
        {
            _stateMachine.ChangeState(_character.IdleState);
        }

        if (!_character.IsGrounded && !_character.IsMoveStair)
        {
            _stateMachine.ChangeState(_character.FallState);
        }

        //Die
        //Crawl
        //Fall
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        ChangeDirection?.Invoke(_horizontalMove);
        _character._rigidbody.position += new Vector3(_horizontalMove, 0, 0) * _character.MovementSpeed * Time.deltaTime;
    }
}
