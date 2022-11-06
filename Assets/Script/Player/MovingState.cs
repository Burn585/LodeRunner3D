using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingState : State
{
    private float _horizontalMove;
    public event UnityAction<float> ChangeDirection;
    public event UnityAction<string> StopHorizontalMove;

    public MovingState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("State enter MovingState");
    }

    public override void HandleInput()
    {
        base.HandleInput();

        _horizontalMove = Input.GetAxis("Horizontal");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (_horizontalMove != 0)
        {
            ChangeDirection?.Invoke(_horizontalMove);
        }
        else
        {
            _stateMachine.ChangeState(_character.IdleState);
            StopHorizontalMove?.Invoke("Idle");
        }
            
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        _character._rigidbody.position += new Vector3(_horizontalMove, 0, 0) * _character.MovementSpeed * Time.deltaTime;
    }
}
