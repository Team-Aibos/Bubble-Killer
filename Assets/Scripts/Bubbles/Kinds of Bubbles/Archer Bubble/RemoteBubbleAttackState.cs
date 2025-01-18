using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteBubbleAttackState : BubbleState
{
    public RemoteBubble remoteBubble;

    public RemoteBubbleAttackState(RemoteBubble _remoteBubble, BubbleStateMachine _stateMachine, string animBoolName)
        : base(_remoteBubble, _stateMachine, animBoolName)
    {
        remoteBubble = _remoteBubble;
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
        if (remoteBubble.distanceToPlayer <= remoteBubble.attackRange)
        {
            remoteBubble.AttackPlayer();  // 执行攻击玩家的逻辑
        }
        else if(remoteBubble.distanceToTower <= remoteBubble.attackRange)
        {
            remoteBubble.AttackTower();  // 执行攻击塔的逻辑
        }
        else
        {
            // 如果既没有玩家也没有塔在攻击范围内，切换回移动状态
            stateMachine.ChangeState(remoteBubble.remoteBubbleMoveState);
            remoteBubble.isMoving = true;
        }

        if (remoteBubble.isDead)
        {
            stateMachine.ChangeState(remoteBubble.remoteBubbleDieState);
        }
    }
}
