using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBubbleMoveState : BubbleState
{
    public CommonBubble commonBubble;

    public CommonBubbleMoveState(CommonBubble _commonBubble, BubbleStateMachine _stateMachine, string animBoolName)
        : base(_commonBubble, _stateMachine, animBoolName)  
    {
        commonBubble = _commonBubble;  
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
        if (commonBubble.DetectPlayer() && commonBubble.isMoving)
        {
            // �����⵽��ң�Ŀ���Ϊ��ҵ�λ�ã���ʼ׷��
            commonBubble.transform.position = Vector3.MoveTowards(commonBubble.transform.position, commonBubble.player.position, commonBubble.movespeed * Time.deltaTime);
        }
        else if (commonBubble.tower != null && commonBubble.isMoving)
        {
            // ���û�м�⵽��ң�����������ƶ�
            commonBubble.transform.position = Vector3.MoveTowards(commonBubble.transform.position, commonBubble.tower.position, commonBubble.movespeed * Time.deltaTime);
        }

        if (!commonBubble.isMoving)
        {
            // ֹͣ�ƶ������й���
            stateMachine.ChangeState(commonBubble.commonBubbleAttackState);
            commonBubble.isAttacking = true;
        }
    }
}
