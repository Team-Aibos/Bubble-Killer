using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttributes
{
    [SerializeField] private float health;
    [SerializeField] private float healthUpper;
    [SerializeField] private float damage;
    [SerializeField] private float range;

    [SerializeField] private Transform transform;

    public void GetHurt(float damage)
    {
        this.health -= damage;
    }

    public bool IsDead()
    {
        return health <= 0;
    }

    public float AttackDamage(Vector2 targetposition)
    {
        if (Vector2.Distance(transform.position, targetposition) <= range)
        {
            return damage;
        }

        return 0;
    }

}
