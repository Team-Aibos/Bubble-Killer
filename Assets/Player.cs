using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Player info")]
    public float HP = 100f;
    public float respawnTime = 3f; // 复活时间
    public float damage = 10f;
    public float moveSpeed = 12f;
    public float dashSpeed = 30f;
    public float dashTime = 0.2f;
    public float dashCD = 0.2f;

    public float lastDash = 100;//上次dash时间间隔

    private bool isDead = false; // 是否死亡

    public int facingDir { get; private set; } = 0;
    private bool facingRight = true;

    #region Components
    public Animator animator { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion
    #region States
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }

    public PlayerMoveState moveState { get; private set; }

    public PlayerDashState dashState { get; private set; }
    #endregion
    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }

    public void Flip()
    {
        facingDir *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
            Flip();
        else if (_x < 0 && facingRight)
            Flip();
    }

    public void PlayerGetHurt(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Die()
    {
        // 禁用人物（例如隐藏或禁用碰撞器）
        gameObject.SetActive(false);

        isDead = true;

        // 开始复活计时
        Invoke("Respawn", respawnTime);
    }

    void Respawn()
    {
        Debug.Log("Player respawned!");

        // 重置生命值
        HP = 100;

        // 启用人物
        gameObject.SetActive(true);

        // 重置死亡状态
        isDead = false;
    }
}
