using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    #region Attributes
    [Header("Tower Attributes")]
    [SerializeField] private float health;    //��ǰ����ֵ
    [SerializeField] private float healthUpper;    //�������ֵ
    [SerializeField] private float damage;    //�����˺�
    [SerializeField] private float attackRate;    //������ȴ
    [SerializeField] private float range;    //������Χ
    [SerializeField] private GameObject bulletPrefab;    //�ӵ�Ԥ����
    [SerializeField] private Transform bulletSpawn;    //�ӵ�������
    [SerializeField] private int currentAdditionalTargets;    //����Ŀ������
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

        // Ѱ�Ҳ���������Ŀ��
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range, LayerMask.GetMask("Enemy"));
        int additionalTargetCount = Mathf.Min(currentAdditionalTargets, enemies.Length - 1); // ���ƶ���Ŀ������

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

        // �������������ӵ�����
        int bulletsNeeded = Mathf.CeilToInt(enemy.GetHealth() / (float)damage);

        // �������ӵ���Ϊ��������������ӵ���
        for (int i = 0; i < bulletsNeeded; i++)
        {
            // ÿ���ӵ����ᵼ���˺���ֱ����������
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

    // ���Ӷ���Ŀ���߼�
    public void AdditionalTargets(int additionalTargets, float duration)
    {
        currentAdditionalTargets += additionalTargets;
        StartCoroutine(RemoveAdditionalTargetsAfterDelay(additionalTargets, duration));
    }

    private IEnumerator RemoveAdditionalTargetsAfterDelay(int additionalTargets, float delay)
    {
        yield return new WaitForSeconds(delay);
        currentAdditionalTargets -= additionalTargets; // ʱ�䵽��ָ�Ĭ��Ŀ����
    }
}