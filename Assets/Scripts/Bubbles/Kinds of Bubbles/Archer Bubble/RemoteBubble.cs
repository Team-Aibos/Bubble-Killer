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

    public float attackRange;  // 远程泡泡的攻击范围

    public float distanceToPlayer;  // 计算泡泡与玩家的距离
    public float distanceToTower;  // 计算泡泡与塔的距离

    public GameObject bulletPrefab;  // 子弹 Prefab
    public Transform shootPoint;     // 子弹发射点

    new private void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        distanceToTower = Vector2.Distance(transform.position, tower.position);

        // 如果距离玩家或塔小于或等于攻击范围，则停止移动
        if (distanceToPlayer <= attackRange || distanceToTower <= attackRange)
        {
            isMoving = false;  // 停止移动
        }

        base.Update();
    }

    // 攻击玩家
    public void AttackPlayer()
    {
        // 生成子弹并设置朝向玩家的方向
        ShootBullet(player.position);
    }

    // 攻击塔
    public void AttackTower()
    {
        // 生成子弹并设置朝向塔的方向
        ShootBullet(tower.position);
    }

    // 发射子弹的逻辑
    private void ShootBullet(Vector3 targetPosition)
    {
        // 生成子弹
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        // 计算目标方向
        Vector2 direction = (targetPosition - shootPoint.position).normalized;

        // 设置子弹的运动方向
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * attackRange;  // 攻击范围可以决定子弹的速度
        }
    }
}
