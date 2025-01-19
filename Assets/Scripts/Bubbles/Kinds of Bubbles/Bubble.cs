using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float health;
    public float movespeed;
    public float damage;
    public Transform tower;  // 泡泡向tower移动
    public Transform player;  // 泡泡向player移动
    public bool isMoving = true;  // 标记泡泡是否在移动
    public bool isAttacking = false;  // 标记泡泡是否在攻击
    public bool isDead = false;  // 标记泡泡是否死亡
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

        // 查找场景中的塔和玩家
        tower = GameObject.FindWithTag("Tower").transform;
        player = GameObject.FindWithTag("Player").transform;
    }

    public void Start()
    {
        anim = GetComponentInChildren<Animator>();
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
            //Destroy(gameObject);

        }
    }

    public float GetHealth()
    {
        return health;
    }

    public bool DetectPlayer()
    {
        // 使用OverlapCircle检查玩家是否在侦察范围内
        Collider2D detectedPlayer = Physics2D.OverlapCircle(transform.position, playerCheckDistance, whatIsPlayer);

        if (detectedPlayer != null)
        {
            player = detectedPlayer.transform;  // 获取玩家的位置
            return true;
        }

        return false;
    }
}
