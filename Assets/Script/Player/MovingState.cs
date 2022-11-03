using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : State
{
    private float _horizontalMove;

    public MovingState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        _horizontalMove = Input.GetAxis("Horizontal");
    }
}
