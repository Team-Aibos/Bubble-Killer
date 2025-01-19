using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    #region Attributes
    private Bubble target;
    private float damage;
    [SerializeField] private float speed = 10.0f;
    private float lifeTime = 3.0f;
    #endregion

    #region Components
    Animator animator;
    #endregion

    public void Initialize(Bubble target,float damage)
    {
        this.target = target;
        this.damage = damage;
    }

    private void Update()
    {
        //����ӵ��Ƿ񳬳��������ڣ������������ӵ�
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }

        if (target != null)
        {
            //�ӵ��ķ��й���
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

            //����ӵ��Ƿ����Ŀ�꣬����Ŀ���������ӵ�
            if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
            {
                target.GetComponent<Bubble>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
