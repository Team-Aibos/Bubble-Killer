using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBubble : Bubble
{
    #region States
    public SplitBubbleMoveState splitBubbleMoveState { get; private set; }
    public SplitBubbleDieState splitBubbleDieState { get; private set; }
    public SplitBubbleAttackState splitBubbleAttackState { get; private set; }

    public bool canSplit = true;  // ��ʾ���Է��� 

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

    void OnCollisionEnter2D(Collision2D collision)  // ����������Ҫ����Ŀ��󹥻�
    {
        // �ж��Ƿ���tower������ײ
        if (collision.gameObject.CompareTag("Tower") || collision.gameObject.CompareTag("Player"))
        {
            if (canSplit)
            {
                for (int i = 0; i < 5; i++)
                {
                    // ���Ƶ�ǰ�����ݲ������ڸ���
                    SplitBubble newBubble = CreateSplitBubbleAtNearbyPosition();
                }
            }
            isMoving = false;  // ֹͣ���ݵ��ƶ�

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

    // ����һ���µ� SplitBubble �ڸ���
    SplitBubble CreateSplitBubbleAtNearbyPosition()
    {
        // ���������ݵ�����λ��
        // ����������� (�������������ҵȷ���)
        Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;

        // ����ƫ�ƾ��룬�����µ�λ��
        float distance = 3.0f;  // ����ƫ�Ƶľ��룬����Խ��λ��ԽԶ
        Vector3 newPosition = transform.position + direction * distance;

        // ����һ���µ� SplitBubble ʵ��
        SplitBubble newBubble = Instantiate(this, newPosition, Quaternion.identity);

        newBubble.isMoving = true;  // ȷ�������ݿ�ʼ�ƶ�
        newBubble.canSplit = false;  // �����ݲ����Է���
        newBubble.health = health / 2;

        // ��ʼ�������ݵ�״̬��
        newBubble.stateMachine.Initialize(newBubble.splitBubbleMoveState);

        return newBubble;
    }
}
