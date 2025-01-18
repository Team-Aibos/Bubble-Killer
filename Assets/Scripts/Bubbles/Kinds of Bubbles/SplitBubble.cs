using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBubble : Bubble
{
    #region States
    public SplitBubbleMoveState splitBubbleMoveState { get; private set; }
    public SplitBubbleDieState splitBubbleDieState { get; private set; }
    public SplitBubbleAttackState splitBubbleAttackState { get; private set; }

    public bool canSplit = true;  // 表示可以分裂 

    #endregion

    new private void Awake()
    {
        base.Awake();

        splitBubbleMoveState = new SplitBubbleMoveState(this, stateMachine, "SplitBubbleMove");
        splitBubbleDieState = new SplitBubbleDieState(this, stateMachine, "SplitBubbleDie");
        splitBubbleAttackState = new SplitBubbleAttackState(this, stateMachine, "SplitBubbleAttack");
    }

    new private void Start()
    {
        base.Start();
        stateMachine.Initialize(splitBubbleMoveState);
    }

    new private void Update()
    {
        base.Update();
    }

    void OnCollisionEnter2D(Collision2D collision)  // 分裂泡泡需要靠近目标后攻击
    {
        // 判断是否与tower发生碰撞
        if (collision.gameObject.CompareTag("Tower") || collision.gameObject.CompareTag("Player"))
        {
            if (canSplit)
            {
                for (int i = 0; i < 3; i++)
                {
                    // 复制当前的泡泡并放置在附近
                    SplitBubble newBubble = CreateSplitBubbleAtNearbyPosition();
                }
            }
            isMoving = false;  // 停止泡泡的移动
        }
    }

    // 创建一个新的 SplitBubble 在附近
    SplitBubble CreateSplitBubbleAtNearbyPosition()
    {
        // 计算新泡泡的生成位置
        // 方向随机生成 (可以是上下左右等方向)
        Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;

        // 增加偏移距离，设置新的位置
        float distance = 3.0f;  // 控制偏移的距离，数字越大，位置越远
        Vector3 newPosition = transform.position + direction * distance;

        // 创建一个新的 SplitBubble 实例
        SplitBubble newBubble = Instantiate(this, newPosition, Quaternion.identity);

        newBubble.isMoving = true;  // 确保新泡泡开始移动
        newBubble.canSplit = false;  // 新泡泡不可以分裂

        // 初始化新泡泡的状态机
        newBubble.stateMachine.Initialize(newBubble.splitBubbleMoveState);

        return newBubble;
    }
}
