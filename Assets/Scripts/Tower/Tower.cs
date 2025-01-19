using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private Transform bulletSpawn;    //子弹出生点
    [SerializeField] private int currentAdditionalTargets;    //额外目标数量
    #endregion

    #region Components
    public Animator animator { get;private set; }
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
        animator = GetComponentInChildren<Animator>();

        stateMachine = new TowerStateMachine();

        idleState = new TowerIdleState(this, stateMachine, "Idle");
        attackState = new TowerAttackState(this, stateMachine, "Attack");
        deadState = new TowerDeadState(this, stateMachine, "Dead");
    }

    public void Start()
    {
        animator = GameObject.FindWithTag("Cannon").GetComponent<Animator>();

        stateMachine.InitialState(idleState);
    }

    public void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }

        stateMachine.currentState.Update();
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

    public void TowerStrike(Bubble enemy)
    {
        TowerAttack(enemy);

        // 寻找并攻击其他目标
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range, LayerMask.GetMask("Enemy"));
        int additionalTargetCount = Mathf.Min(currentAdditionalTargets, enemies.Length - 1); // 限制额外目标数量

        for (int i = 0; i < additionalTargetCount; i++)
        {
            Bubble extraTarget = enemies[i].GetComponent<Bubble>();
            if (extraTarget != enemy)
            {
                TowerAttack(extraTarget);
            }
        }
    }

    public void TowerAttack(Bubble enemy)
    {

        // 计算敌人所需的子弹数量
        int bulletsNeeded = Mathf.CeilToInt(enemy.GetHealth() / (float)damage);

        // 最大射出子弹数为敌人死亡所需的子弹数
        for (int i = 0; i < bulletsNeeded; i++)
        {
            // 每发子弹都会导致伤害，直到敌人死亡
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<TowerBullet>().Initialize(enemy, damage);
        }
    }

    public float GetRange()
    {
        return range;
    }
    public float GetAttackRate()
    {
        return attackRate;
    }

    // 增加额外目标逻辑
    public void AdditionalTargets(int additionalTargets, float duration)
    {
        currentAdditionalTargets += additionalTargets;
        StartCoroutine(RemoveAdditionalTargetsAfterDelay(additionalTargets, duration));
    }

    private IEnumerator RemoveAdditionalTargetsAfterDelay(int additionalTargets, float delay)
    {
        yield return new WaitForSeconds(delay);
        currentAdditionalTargets -= additionalTargets; // 时间到后恢复默认目标数
    }
}