using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDeadState : TowerState
{
    public TowerDeadState(Tower tower, TowerStateMachine stateMachine, string stateName) : base(tower, stateMachine, stateName)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
