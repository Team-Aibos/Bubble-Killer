using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab; // 子弹预制体
    public Transform firePoint; // 子弹发射点

    void Update()
    {
        // 检测开火输入（例如按下鼠标左键）
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 实例化子弹
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 设置子弹的初始速度
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.speed = 10f; // 设置子弹速度
        }
    }
}