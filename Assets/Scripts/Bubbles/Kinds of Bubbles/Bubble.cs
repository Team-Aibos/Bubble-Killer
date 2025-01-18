using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float health;
    public float movespeed;
    public float damage;
    public Transform tower;  // ������tower�ƶ�
    public Transform player;  // ������player�ƶ�
    public bool isMoving = true;  // ��������Ƿ����ƶ�
    public bool isAttacking = false;  // ��������Ƿ��ڹ���
    public bool isDead = false;  // ��������Ƿ�����
    [SerializeField] private float playerCheckDistance;
    [SerializeField] private LayerMask whatIsPlayer;

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    #endregion

    #region States
    public BubbleStateMachine stateMachine { get; private set; }

    #endregion

    public void Awake()
    {
        stateMachine = new BubbleStateMachine();

        // ���ҳ����е��������
        tower = GameObject.FindWithTag("Tower").transform;
        player = GameObject.FindWithTag("Player").transform;
    }

    public void Start()
    {
        //anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        stateMachine.currentState.Update();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }

    public bool DetectPlayer()
    {
        // ʹ��OverlapCircle�������Ƿ�����췶Χ��
        Collider2D detectedPlayer = Physics2D.OverlapCircle(transform.position, playerCheckDistance, whatIsPlayer);

        if (detectedPlayer != null)
        {
            player = detectedPlayer.transform;  // ��ȡ��ҵ�λ��
            return true;
        }

        return false;
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerCheckDistance);
    }
}
