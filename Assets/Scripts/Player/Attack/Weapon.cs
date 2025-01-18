using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject bulletPrefab; // 子弹预制体
    public Transform firePoint; // 子弹发射点
    public float shootInterval = 0.2f; // 射击间隔
    private float lastShootTime; // 上次射击时间
    private int bulletCount = 1; // 初始弹道数量
    private float totalSpreadAngle = 90f; // 弹道总分布角度（90度）

    [Header("Melee Attack Settings")]
    public float meleeRange = 2f; // 近战攻击半径
    public float meleeAngle = 120f; // 近战攻击角度（扇形区域）
    public int meleeDamage = 10; // 近战攻击伤害
    public float attackInterval = 0.5f; // 近战间隔
    private float lastAttackTime; // 上次攻击时间
    public LayerMask enemyLayer; // 怪物所在的层级

    //private Animator animator;

    //private void Start()
    //{
    //    animator = GetComponent<Animator>();
    //    lastShootTime = -shootInterval; // 初始化上次射击时间
    //}

    void Update()
    {
        // 检测射击输入（按住鼠标左键）
        if (Input.GetButton("Fire1"))
        {
            if (Time.time - lastShootTime >= shootInterval)
            {
                Shoot();
                lastShootTime = Time.time; // 更新上次射击时间
            }
        }

        // 检测近战攻击输入（按下鼠标右键）
        if (Input.GetButtonDown("Fire2"))
        {
            if (Time.time - lastAttackTime >= attackInterval)
            {
                MeleeAttack();
                lastAttackTime = Time.time; // 更新上次射击时间
            }
        }
    }

    void Shoot()
    {
        if (bulletCount == 1)
        {
            // 只有一个弹道时，直接使用 firePoint.rotation
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // 设置子弹速度
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.speed = 10f; // 设置子弹速度
            }
        }
        else
        {
            // 多个弹道时，计算角度偏移
            for (int i = 0; i < bulletCount; i++)
            {
                float angleOffset = (totalSpreadAngle / (bulletCount - 1)) * i - (totalSpreadAngle / 2);
                Quaternion rotation = firePoint.rotation * Quaternion.Euler(0, 0, angleOffset);

                // 生成子弹
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);

                // 设置子弹速度
                Bullet bulletScript = bullet.GetComponent<Bullet>();
                if (bulletScript != null)
                {
                    bulletScript.speed = 10f; // 设置子弹速度
                }
            }
        }
    }

    void MeleeAttack()
    {
        //// 播放近战攻击动画
        //animator.SetTrigger("MeleeAttack");

        // 检测扇形区域内的所有怪物
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, meleeRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            // 判断怪物是否在扇形区域内
            Vector2 directionToEnemy = (enemy.transform.position - transform.position).normalized;
            float angleToEnemy = Vector2.Angle(transform.right, directionToEnemy);

            if (angleToEnemy < meleeAngle / 2)
            {
                // 调用怪物的受伤函数
                Bubble enemyScript = enemy.GetComponent<Bubble>();
                if (enemyScript != null)
                {
                    enemyScript.TakeDamage(meleeDamage);
                }
            }
        }
    }

    // 升级武器：增加两个弹道
    public void UpgradeWeapon()
    {
        bulletCount += 2; // 每次增加两个弹道
        if (bulletCount < 1)
        {
            bulletCount = 1; // 确保 bulletCount 至少为 1
        }
    }

    // 绘制近战攻击范围的Gizmos（用于调试）
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, meleeRange);

        // 绘制扇形区域
        Vector3 forward = transform.right;
        Vector3 leftBound = Quaternion.Euler(0, 0, -meleeAngle / 2) * forward * meleeRange;
        Vector3 rightBound = Quaternion.Euler(0, 0, meleeAngle / 2) * forward * meleeRange;

        Gizmos.DrawLine(transform.position, transform.position + leftBound);
        Gizmos.DrawLine(transform.position, transform.position + rightBound);
    }
}
