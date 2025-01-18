using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteBubbleMoveState : BubbleState
{
    public RemoteBubble remoteBubble;

    public RemoteBubbleMoveState(RemoteBubble _remoteBubble, BubbleStateMachine _stateMachine, string animBoolName)
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
        // ����Ƿ����������췶Χ��
        if (remoteBubble.DetectPlayer() && remoteBubble.isMoving)
        {
            // �����⵽��ң�Ŀ���Ϊ��ҵ�λ�ã���ʼ׷��
            remoteBubble.transform.position = Vector3.MoveTowards(remoteBubble.transform.position, remoteBubble.player.position, remoteBubble.movespeed * Time.deltaTime);
        }
        else if (remoteBubble.tower != null && remoteBubble.isMoving)
        {
            // ���û�м�⵽��ң�����������ƶ�
            remoteBubble.transform.position = Vector3.MoveTowards(remoteBubble.transform.position, remoteBubble.tower.position, remoteBubble.movespeed * Time.deltaTime);
        }

        if (!remoteBubble.isMoving)
        {
            // ֹͣ�ƶ������й���
            stateMachine.ChangeState(remoteBubble.remoteBubbleAttackState);
            remoteBubble.isAttacking = true;
        }

        if(remoteBubble.isDead)
        {
            stateMachine.ChangeState(remoteBubble.remoteBubbleDieState);
        }
    }
}
