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
        tower.animator.SetBool("Attack", true);
       
    }

    public override void Update()
    {
        Bubble target = FindEnemy();
        if (target == null)
        {
            tower.animator.SetBool("Attack", false);
            stateMachine.ChangeState(tower.idleState);
            return;
        }

        if (Time.time - attackTimer > tower.GetAttackRate())
        {
            attackTimer = Time.time;
            tower.animator.SetTrigger("Shoot");
            tower.TowerStrike(target);
            tower.animator.SetBool("Attack", false);
        }
    }

    public override void Exit()
    {

    }
}
