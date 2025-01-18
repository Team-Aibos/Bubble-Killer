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

    public float dashDistance;  // �������ݵĳ�̾���
    public bool isDashing = false;  // 

    new private void Update()
    {
        // ������������ҵľ���
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        // �������������ľ���
        float distanceToTower = Vector2.Distance(transform.position, tower.position);

        // ���������һ���С�ڻ���ڹ�����Χ����ֹͣ�ƶ�
        if (distanceToPlayer <= dashDistance || distanceToTower <= dashDistance)
        {
            isMoving = false;  // ֹͣ�ƶ�
        }

        base.Update();
    }

    void OnCollisionEnter2D(Collision2D collision)  // ����������Ҫ����Ŀ��󹥻�
    {
        // �ж��Ƿ���tower������ײ
        if (collision.gameObject.CompareTag("Tower") || collision.gameObject.CompareTag("Player"))
        {
            isDashing = false;  // ֹͣ���ݵ��ƶ�

            if (collision.gameObject.CompareTag("Player"))
            {
                Player target = collision.gameObject.GetComponent<Player>();

                if (target != null)
                {
                    target.PlayerGetHurt(damage);
                }
            }

            if (collision.gameObject.CompareTag("Tower"))
            {
                Tower target = collision.gameObject.GetComponent<Tower>();

                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }
    }
}
