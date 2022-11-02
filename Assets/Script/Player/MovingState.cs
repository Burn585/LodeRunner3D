using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : State
{
    public MovingState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
}
