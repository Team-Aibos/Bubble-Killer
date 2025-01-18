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

    public float attackRange;  // Զ�����ݵĹ�����Χ

    public float distanceToPlayer;  // ������������ҵľ���
    public float distanceToTower;  // �������������ľ���

    public GameObject bulletPrefab;  // �ӵ� Prefab
    public Transform shootPoint;     // �ӵ������

    new private void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        distanceToTower = Vector2.Distance(transform.position, tower.position);

        // ���������һ���С�ڻ���ڹ�����Χ����ֹͣ�ƶ�
        if (distanceToPlayer <= attackRange || distanceToTower <= attackRange)
        {
            isMoving = false;  // ֹͣ�ƶ�
        }

        base.Update();
    }

    // �������
    public void AttackPlayer()
    {
        // �����ӵ������ó�����ҵķ���
        ShootBullet(player.position);
    }

    // ������
    public void AttackTower()
    {
        // �����ӵ������ó������ķ���
        ShootBullet(tower.position);
    }

    // �����ӵ����߼�
    private void ShootBullet(Vector3 targetPosition)
    {
        // �����ӵ�
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        // ����Ŀ�귽��
        Vector2 direction = (targetPosition - shootPoint.position).normalized;

        // �����ӵ����˶�����
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * attackRange;  // ������Χ���Ծ����ӵ����ٶ�
        }
    }
}
