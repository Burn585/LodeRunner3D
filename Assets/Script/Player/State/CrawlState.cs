using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlState : State
{
    public CrawlState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void Transition()
    {
        base.Transition();

        //Fall
        //Run
        //Die
    }
}
