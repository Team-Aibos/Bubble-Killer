using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackState : TowerState
{
    private float attackTimer;

    public TowerAttackState(Tower tower, TowerStateMachine stateMachine, string stateName) : base(tower, stateMachine, stateName)
    {

    }

    public override void Enter()
    {
        attackTimer = Time.time;
        //tower.animator.SetTrigger("TowerAttack");
    }

    public override void Update()
    {
        Transform target = FindEnemy();
        if (target == null)
        {
            tower.stateMachine.ChangeState(tower.idleState);
            return;
        }

        if (Time.time - attackTimer > tower.GetAttackRate())
        {
            attackTimer = Time.time;
            tower.TowerStrike(target);
        }
    }

    public override void Exit()
    {

    }
}
