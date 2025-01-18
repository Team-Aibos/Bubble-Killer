using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // 子弹速度
    public float lifeTime = 3f; // 子弹存在时间
    public int damage = 1; // 子弹伤害

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime); // 子弹在 lifeTime 秒后自动销毁
    }

    void Update()
    {
        // 子弹向前移动
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 检测碰撞对象是否是怪物
        if (collision.gameObject.CompareTag("Bubble"))
        {
            // 调用怪物的受伤函数
            Bubble target = collision.gameObject.GetComponent<Bubble>();
            if (target != null)
            {
                target.TakeDamage(damage); // 减少怪物生命值
            }

            // 销毁子弹
            Destroy(gameObject);
        }
    }
}