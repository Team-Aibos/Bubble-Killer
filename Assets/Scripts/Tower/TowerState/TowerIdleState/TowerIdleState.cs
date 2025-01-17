using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerIdleState : TowerState
{
    public TowerIdleState(Tower tower, TowerStateMachine stateMachine, string stateName) : base(tower, stateMachine, stateName)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        tower.animator.Play("Idle");

        Transform enemy = FindEnemy();
        if (enemy!= null)
        {
            stateMachine.ChangeState(tower.attackState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
