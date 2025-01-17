using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    #region Attributes
    [Header("Tower Attributes")]
    [SerializeField] private float health;    //当前生命值
    [SerializeField] private float healthUpper;    //最大生命值
    [SerializeField] private float damage;    //攻击伤害
    [SerializeField] private float attackRate;    //攻击冷却
    [SerializeField] private float range;    //攻击范围
    [SerializeField] private GameObject bulletPrefab;    //子弹预制体
    #endregion

    #region Components
    public Animator animator { get;private set; }
    public Transform bulletSpawn { get; private set; }
    #endregion

    #region State
    public TowerStateMachine stateMachine { get; private set; }

    public TowerIdleState idleState { get; private set; }
    public TowerAttackState attackState { get; private set; }
    public TowerDeadState deadState { get; private set; }
    #endregion

    public Tower(float healthUpper, float damage, float range)
    {
        this.health = healthUpper;
        this.healthUpper = healthUpper;
        this.damage = damage;
        this.range = range;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();

        stateMachine = new TowerStateMachine();

        idleState = new TowerIdleState(this, stateMachine, "Idle");
        attackState = new TowerAttackState(this, stateMachine, "Attack");
        deadState = new TowerDeadState(this, stateMachine, "Dead");
    }

    public void Start()
    {
        animator = GetComponent<Animator>();

        stateMachine.InitialState(idleState);
    }

    public float GetHealth()
    {
        return health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            stateMachine.ChangeState(deadState);
        }
    }

    public void TowerAttack(Transform enemy)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<TowerBullet>().Initialize(enemy, damage);
    }

    public float GetRange()
    {
        return range;
    }
    public float GetAttackRate()
    {
        return attackRate;
    }
}