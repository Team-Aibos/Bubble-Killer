using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    #region Attributes
    private Transform target;
    private float damage;
    [SerializeField] private float speed = 10.0f;
    #endregion

    #region Components
    Animator animator;
    #endregion

    public void Initialize(Transform target,float damage)
    {
        this.target = target;
        this.damage = damage;
        animator = GetComponent<Animator>();
        //animator.Play("BulletFly");
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //�ӵ��ķ��й���
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        //����ӵ��Ƿ����Ŀ�꣬����Ŀ���������ӵ�
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            //target.GetComponent<Bubble>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
