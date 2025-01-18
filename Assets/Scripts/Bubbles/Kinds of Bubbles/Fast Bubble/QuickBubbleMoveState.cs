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

        // 检测是否有玩家在侦察范围内
        if (quickBubble.DetectPlayer() && quickBubble.isMoving)
        {
            // 如果检测到玩家，目标变为玩家的位置，开始追击
            quickBubble.transform.position = Vector3.MoveTowards(quickBubble.transform.position, quickBubble.player.position, quickBubble.movespeed * Time.deltaTime);
        }
        else if (quickBubble.tower != null && quickBubble.isMoving)
        {
            // 如果没有检测到玩家，则继续向塔移动
            quickBubble.transform.position = Vector3.MoveTowards(quickBubble.transform.position, quickBubble.tower.position, quickBubble.movespeed * Time.deltaTime);
        }

        if (!quickBubble.isMoving)
        {
            // 进行冲刺
            stateMachine.ChangeState(quickBubble.quickBubbleDashState);
            quickBubble.isDashing = true;
        }
    }
}
