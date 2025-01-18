using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMultiple : Item
{
    [SerializeField] private int additionalTargets; // ���ӵ�Ŀ����
    [SerializeField] private float duration;      // ����Ч������ʱ��
    private Tower tower;
    private float lastTime = 3.0f;    //��������

    void Start()
    {
        tower = GameObject.FindWithTag("Tower").GetComponent<Tower>();
    }

    public void Update()
    {
        ItemDisappear();
    }

    public void ItemDisappear()
    {
        if (lastTime <= 0)
            Destroy(gameObject);
    }

    public override void OnPickUp()
    {
        tower.AdditionalTargets(additionalTargets, duration);
    }
}