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
        // 检测是否有玩家在侦察范围内
        if (commonBubble.DetectPlayer() && commonBubble.isMoving)
        {
            // 如果检测到玩家，目标变为玩家的位置，开始追击
            commonBubble.transform.position = Vector3.MoveTowards(commonBubble.transform.position, commonBubble.player.position, commonBubble.movespeed * Time.deltaTime);
        }
        else if (commonBubble.tower != null && commonBubble.isMoving)
        {
            // 如果没有检测到玩家，则继续向塔移动
            commonBubble.transform.position = Vector3.MoveTowards(commonBubble.transform.position, commonBubble.tower.position, commonBubble.movespeed * Time.deltaTime);
        }

        if (!commonBubble.isMoving)
        {
            // 停止移动并进行攻击
            stateMachine.ChangeState(commonBubble.commonBubbleAttackState);
            commonBubble.isAttacking = true;
        }

        if(commonBubble.isDead)
        {
            stateMachine.ChangeState(commonBubble.commonBubbleDieState);
        }
    }
}
