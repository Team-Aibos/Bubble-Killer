using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBubbleMoveState : BubbleState
{
    public SplitBubble splitBubble;

    public SplitBubbleMoveState(SplitBubble _splitBubble, BubbleStateMachine _stateMachine, string animBoolName)
       : base(_splitBubble, _stateMachine, animBoolName)
    {
        splitBubble = _splitBubble;
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
        if (splitBubble.DetectPlayer() && splitBubble.isMoving)
        {
            // �����⵽��ң�Ŀ���Ϊ��ҵ�λ�ã���ʼ׷��
            splitBubble.transform.position = Vector3.MoveTowards(splitBubble.transform.position, splitBubble.player.position, splitBubble.movespeed * Time.deltaTime);
        }
        else if (splitBubble.tower != null && splitBubble.isMoving)
        {
            // ���û�м�⵽��ң�����������ƶ�
            splitBubble.transform.position = Vector3.MoveTowards(splitBubble.transform.position, splitBubble.tower.position, splitBubble.movespeed * Time.deltaTime);
        }

        if (!splitBubble.isMoving)
        {
            // ֹͣ�ƶ������й���
            stateMachine.ChangeState(splitBubble.splitBubbleAttackState);
            splitBubble.isAttacking = true;
        }
    }
}
