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
        // 检测是否有玩家在侦察范围内
        if (remoteBubble.DetectPlayer() && remoteBubble.isMoving)
        {
            // 如果检测到玩家，目标变为玩家的位置，开始追击
            remoteBubble.transform.position = Vector3.MoveTowards(remoteBubble.transform.position, remoteBubble.player.position, remoteBubble.movespeed * Time.deltaTime);
        }
        else if (remoteBubble.tower != null && remoteBubble.isMoving)
        {
            // 如果没有检测到玩家，则继续向塔移动
            remoteBubble.transform.position = Vector3.MoveTowards(remoteBubble.transform.position, remoteBubble.tower.position, remoteBubble.movespeed * Time.deltaTime);
        }

        if (!remoteBubble.isMoving)
        {
            // 停止移动并进行攻击
            stateMachine.ChangeState(remoteBubble.remoteBubbleAttackState);
            remoteBubble.isAttacking = true;
        }
    }
}
