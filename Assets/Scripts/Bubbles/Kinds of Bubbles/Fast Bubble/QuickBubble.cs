using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickBubble : Bubble
{
    #region States
    public QuickBubbleMoveState quickBubbleMoveState { get; private set; }
    public QuickBubbleDashState quickBubbleDashState { get; private set; }
    public QuickBubbleDieState quickBubbleDieState { get; private set; }
    public QuickBubbleAttackState quickBubbleAttackState { get; private set; }

    #endregion

    new private void Awake()
    {
        base.Awake();

        quickBubbleMoveState = new QuickBubbleMoveState(this, stateMachine, "QuickBubbleMove");
        quickBubbleDashState = new QuickBubbleDashState(this, stateMachine, "QuickBubbleDash");
        quickBubbleDieState = new QuickBubbleDieState(this, stateMachine, "QuickBubbleDie");
        quickBubbleAttackState = new QuickBubbleAttackState(this, stateMachine, "QuickBubbleAttack");
    }

    new private void Start()
    {
        base.Start();
        stateMachine.Initialize(quickBubbleMoveState);
    }

    public float dashDistance;  // 快速泡泡的冲刺距离
    public bool isDashing = false;  // 

    new private void Update()
    {
        // 计算泡泡与玩家的距离
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        // 计算泡泡与塔的距离
        float distanceToTower = Vector2.Distance(transform.position, tower.position);

        // 如果距离玩家或塔小于或等于攻击范围，则停止移动
        if (distanceToPlayer <= dashDistance || distanceToTower <= dashDistance)
        {
            isMoving = false;  // 停止移动
        }

        base.Update();
    }

    void OnCollisionEnter2D(Collision2D collision)  // 快速泡泡需要靠近目标后攻击
    {
        // 判断是否与tower发生碰撞
        if (collision.gameObject.CompareTag("Tower") || collision.gameObject.CompareTag("Player"))
        {
            isDashing = false;  // 停止泡泡的移动
        }
    }
}
