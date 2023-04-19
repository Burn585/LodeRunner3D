using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClimbState : State
{
    public event UnityAction<string> StartStateClimb;
    public event UnityAction<string> EndStateClimb;
    public event UnityAction<bool> PauseAnimation;

    private float _verticalMove;
    private float _horizontalMove;
    private float _centerStair = 0.8f;

    public ClimbState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StartStateClimb?.Invoke(AnimatorPlayer.States.Climb);
        _character._rigidbody.position = new Vector3(_character.StairPosition.x + _centerStair, _character._rigidbody.position.y, _character._rigidbody.position.z);
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

        if(_verticalMove == 0 || !_character.IsMoveStair)
        {
            _stateMachine.ChangeState(_character.IdleState);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

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
        EndStateClimb?.Invoke(AnimatorPlayer.States.Climb);
    }
}
