using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteBubble : Bubble
{
    #region States
    public RemoteBubbleMoveState remoteBubbleMoveState { get; private set; }
    public RemoteBubbleDieState remoteBubbleDieState { get; private set; }
    public RemoteBubbleAttackState remoteBubbleAttackState { get; private set; }

    #endregion
    new private void Awake()
    {
        base.Awake();

        remoteBubbleMoveState = new RemoteBubbleMoveState(this, stateMachine, "RemoteBubbleMove");
        remoteBubbleDieState = new RemoteBubbleDieState(this, stateMachine, "RemoteBubbleDie");
        remoteBubbleAttackState = new RemoteBubbleAttackState(this, stateMachine, "RemoteBubbleAttack");
    }

    new private void Start()
    {
        base.Start();
        stateMachine.Initialize(remoteBubbleMoveState);
    }

    public float attackRange; // 远程泡泡的攻击范围

    new private void Update()
    {
        // 计算泡泡与玩家的距离
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        // 计算泡泡与塔的距离
        float distanceToTower = Vector2.Distance(transform.position, tower.position);

        // 如果距离玩家或塔小于或等于攻击范围，则停止移动
        if (distanceToPlayer <= attackRange || distanceToTower <= attackRange)
        {
            isMoving = false;  // 停止移动
        }

        base.Update();
    }
}
