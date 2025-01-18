using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickBubbleDashState : BubbleState
{
    public QuickBubble quickBubble;

    public QuickBubbleDashState(QuickBubble _quickBubble, BubbleStateMachine _stateMachine, string animBoolName)
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

        // 检测是否有玩家在侦察范围内
        if (quickBubble.DetectPlayer() && quickBubble.isDashing)
        {
            // 如果检测到玩家，目标变为玩家的位置，开始追击
            quickBubble.transform.position = Vector3.MoveTowards(quickBubble.transform.position, quickBubble.player.position, quickBubble.movespeed * 2 * Time.deltaTime);
        }
        else if (quickBubble.tower != null && quickBubble.isDashing)
        {
            // 如果没有检测到玩家，则继续向塔移动
            quickBubble.transform.position = Vector3.MoveTowards(quickBubble.transform.position, quickBubble.tower.position, quickBubble.movespeed * 2 * Time.deltaTime);
        }

        if (!quickBubble.isDashing)
        {
            stateMachine.ChangeState(quickBubble.quickBubbleAttackState);
            quickBubble.isAttacking = true;
        }

        if (quickBubble.isDead)
        {
            stateMachine.ChangeState(quickBubble.quickBubbleDieState);
        }
    }
}
