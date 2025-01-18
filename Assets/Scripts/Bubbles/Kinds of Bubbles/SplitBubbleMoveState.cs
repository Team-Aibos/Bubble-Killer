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
        // 检测是否有玩家在侦察范围内
        if (splitBubble.DetectPlayer() && splitBubble.isMoving)
        {
            // 如果检测到玩家，目标变为玩家的位置，开始追击
            splitBubble.transform.position = Vector3.MoveTowards(splitBubble.transform.position, splitBubble.player.position, splitBubble.movespeed * Time.deltaTime);
        }
        else if (splitBubble.tower != null && splitBubble.isMoving)
        {
            // 如果没有检测到玩家，则继续向塔移动
            splitBubble.transform.position = Vector3.MoveTowards(splitBubble.transform.position, splitBubble.tower.position, splitBubble.movespeed * Time.deltaTime);
        }

        if (!splitBubble.isMoving)
        {
            // 停止移动并进行攻击
            stateMachine.ChangeState(splitBubble.splitBubbleAttackState);
            splitBubble.isAttacking = true;
        }
    }
}
