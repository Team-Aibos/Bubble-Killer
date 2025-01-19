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

        if (remoteBubble.lastAttackTime + remoteBubble.attackGap <= Time.time && remoteBubble.distanceToPlayer <= remoteBubble.attackRange)
        {
            remoteBubble.AttackPlayer();  // ִ�й�����ҵ��߼�
            remoteBubble.lastAttackTime = Time.time;
        }
        else if(remoteBubble.lastAttackTime + remoteBubble.attackGap <= Time.time && remoteBubble.distanceToTower <= remoteBubble.attackRange)
        {
            remoteBubble.AttackTower();  // ִ�й��������߼�
            remoteBubble.lastAttackTime = Time.time;
        }
        else
        {
            // �����û�����Ҳû�����ڹ�����Χ�ڣ��л����ƶ�״̬
            stateMachine.ChangeState(remoteBubble.remoteBubbleMoveState);
            remoteBubble.isMoving = true;
        }

        if (remoteBubble.isDead)
        {
            stateMachine.ChangeState(remoteBubble.remoteBubbleDieState);
        }
    }
}
