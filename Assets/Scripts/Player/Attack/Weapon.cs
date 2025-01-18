using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject bulletPrefab; // �ӵ�Ԥ����
    public Transform firePoint; // �ӵ������
    public float shootInterval = 0.2f; // ������
    private float lastShootTime; // �ϴ����ʱ��
    private int bulletCount = 1; // ��ʼ��������
    private float totalSpreadAngle = 90f; // �����ֲܷ��Ƕȣ�90�ȣ�

    [Header("Melee Attack Settings")]
    public float meleeRange = 2f; // ��ս�����뾶
    public float meleeAngle = 120f; // ��ս�����Ƕȣ���������
    public int meleeDamage = 10; // ��ս�����˺�
    public float attackInterval = 0.5f; // ��ս���
    private float lastAttackTime; // �ϴι���ʱ��
    public LayerMask enemyLayer; // �������ڵĲ㼶

    //private Animator animator;

    //private void Start()
    //{
    //    animator = GetComponent<Animator>();
    //    lastShootTime = -shootInterval; // ��ʼ���ϴ����ʱ��
    //}

    void Update()
    {
        // ���������루��ס��������
        if (Input.GetButton("Fire1"))
        {
            if (Time.time - lastShootTime >= shootInterval)
            {
                Shoot();
                lastShootTime = Time.time; // �����ϴ����ʱ��
            }
        }

        // ����ս�������루��������Ҽ���
        if (Input.GetButtonDown("Fire2"))
        {
            if (Time.time - lastAttackTime >= attackInterval)
            {
                MeleeAttack();
                lastAttackTime = Time.time; // �����ϴ����ʱ��
            }
        }
    }

    void Shoot()
    {
        if (bulletCount == 1)
        {
            // ֻ��һ������ʱ��ֱ��ʹ�� firePoint.rotation
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // �����ӵ��ٶ�
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.speed = 10f; // �����ӵ��ٶ�
            }
        }
        else
        {
            // �������ʱ������Ƕ�ƫ��
            for (int i = 0; i < bulletCount; i++)
            {
                float angleOffset = (totalSpreadAngle / (bulletCount - 1)) * i - (totalSpreadAngle / 2);
                Quaternion rotation = firePoint.rotation * Quaternion.Euler(0, 0, angleOffset);

                // �����ӵ�
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);

                // �����ӵ��ٶ�
                Bullet bulletScript = bullet.GetComponent<Bullet>();
                if (bulletScript != null)
                {
                    bulletScript.speed = 10f; // �����ӵ��ٶ�
                }
            }
        }
    }

    void MeleeAttack()
    {
        //// ���Ž�ս��������
        //animator.SetTrigger("MeleeAttack");

        // ������������ڵ����й���
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, meleeRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            // �жϹ����Ƿ�������������
            Vector2 directionToEnemy = (enemy.transform.position - transform.position).normalized;
            float angleToEnemy = Vector2.Angle(transform.right, directionToEnemy);

            if (angleToEnemy < meleeAngle / 2)
            {
                // ���ù�������˺���
                Bubble enemyScript = enemy.GetComponent<Bubble>();
                if (enemyScript != null)
                {
                    enemyScript.TakeDamage(meleeDamage);
                }
            }
        }
    }

    // ����������������������
    public void UpgradeWeapon()
    {
        bulletCount += 2; // ÿ��������������
        if (bulletCount < 1)
        {
            bulletCount = 1; // ȷ�� bulletCount ����Ϊ 1
        }
    }

    // ���ƽ�ս������Χ��Gizmos�����ڵ��ԣ�
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, meleeRange);

        // ������������
        Vector3 forward = transform.right;
        Vector3 leftBound = Quaternion.Euler(0, 0, -meleeAngle / 2) * forward * meleeRange;
        Vector3 rightBound = Quaternion.Euler(0, 0, meleeAngle / 2) * forward * meleeRange;

        Gizmos.DrawLine(transform.position, transform.position + leftBound);
        Gizmos.DrawLine(transform.position, transform.position + rightBound);
    }
}
