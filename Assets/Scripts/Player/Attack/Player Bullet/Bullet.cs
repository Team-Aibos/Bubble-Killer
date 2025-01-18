using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // �ӵ��ٶ�
    public float lifeTime = 3f; // �ӵ�����ʱ��
    public int damage = 1; // �ӵ��˺�

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime); // �ӵ��� lifeTime ����Զ�����
    }

    void Update()
    {
        // �ӵ���ǰ�ƶ�
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // �����ײ�����Ƿ��ǹ���
        if (collision.gameObject.CompareTag("Bubble"))
        {
            // ���ù�������˺���
            Bubble target = collision.gameObject.GetComponent<Bubble>();
            if (target != null)
            {
                target.TakeDamage(damage); // ���ٹ�������ֵ
            }

            // �����ӵ�
            Destroy(gameObject);
        }
    }
}