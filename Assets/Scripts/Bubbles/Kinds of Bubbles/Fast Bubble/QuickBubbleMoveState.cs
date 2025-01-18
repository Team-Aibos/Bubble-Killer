using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickBubbleMoveState : BubbleState
{
    public QuickBubble quickBubble;

    public QuickBubbleMoveState(QuickBubble _quickBubble, BubbleStateMachine _stateMachine, string animBoolName)
       : base(_quickBubble, _stateMachine, animBoolName)
    {
        quickBubble = _quickBubble;
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
        if (quickBubble.DetectPlayer() && quickBubble.isMoving)
        {
            // �����⵽��ң�Ŀ���Ϊ��ҵ�λ�ã���ʼ׷��
            quickBubble.transform.position = Vector3.MoveTowards(quickBubble.transform.position, quickBubble.player.position, quickBubble.movespeed * Time.deltaTime);
        }
        else if (quickBubble.tower != null && quickBubble.isMoving)
        {
            // ���û�м�⵽��ң�����������ƶ�
            quickBubble.transform.position = Vector3.MoveTowards(quickBubble.transform.position, quickBubble.tower.position, quickBubble.movespeed * Time.deltaTime);
        }

        if (!quickBubble.isMoving)
        {
            // ���г��
            stateMachine.ChangeState(quickBubble.quickBubbleDashState);
            quickBubble.isDashing = true;
        }
    }
}
