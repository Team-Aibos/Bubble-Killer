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

    public float attackRange; // Զ�����ݵĹ�����Χ

    new private void Update()
    {
        // ������������ҵľ���
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        // �������������ľ���
        float distanceToTower = Vector2.Distance(transform.position, tower.position);

        // ���������һ���С�ڻ���ڹ�����Χ����ֹͣ�ƶ�
        if (distanceToPlayer <= attackRange || distanceToTower <= attackRange)
        {
            isMoving = false;  // ֹͣ�ƶ�
        }

        base.Update();
    }
}
