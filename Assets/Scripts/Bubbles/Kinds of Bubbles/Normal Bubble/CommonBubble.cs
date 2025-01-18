using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBubble : Bubble
{
    #region States
    public CommonBubbleMoveState commonBubbleMoveState  { get; private set; }
    public CommonBubbleDieState commonBubbleDieState { get; private set; }
    public CommonBubbleAttackState commonBubbleAttackState { get; private set; }

    #endregion

    new private void Awake()
    {
        base.Awake();

        commonBubbleMoveState = new CommonBubbleMoveState(this, stateMachine, "CommonBubbleMove");
        commonBubbleDieState = new CommonBubbleDieState(this, stateMachine, "CommonBubbleDie");
        commonBubbleAttackState = new CommonBubbleAttackState(this, stateMachine, "CommonBubbleAttack");
    }

    new private void Start()
    {
        base.Start();
        stateMachine.Initialize(commonBubbleMoveState);
    }

    new private void Update()
    {
        base.Update();
    }

    void OnCollisionEnter2D(Collision2D collision)  // 普通泡泡需要靠近目标后攻击
    {
        // 判断是否与tower发生碰撞
        if (collision.gameObject.CompareTag("Tower") || collision.gameObject.CompareTag("Player"))
        {
            isMoving = false;  // 停止泡泡的移动
        }
    }
}
