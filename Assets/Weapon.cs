using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab; // �ӵ�Ԥ����
    public Transform firePoint; // �ӵ������

    void Update()
    {
        // ��⿪�����루���簴����������
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // ʵ�����ӵ�
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // �����ӵ��ĳ�ʼ�ٶ�
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.speed = 10f; // �����ӵ��ٶ�
        }
    }
}