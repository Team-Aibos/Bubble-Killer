using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMultiple : Item
{
    [SerializeField] private int additionalTargets; // 增加的目标数
    [SerializeField] private float duration;      // 道具效果持续时间
    private Tower tower;
    private float lastTime = 3.0f;    //生命周期

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