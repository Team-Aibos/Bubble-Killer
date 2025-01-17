using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    #region Attributes
    [Header("Tower Attributes")]
    [SerializeField] private float health;
    [SerializeField] private float healthUpper;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    #endregion

    public Tower(float healthUpper, float damage, float range)
    {
        this.health = healthUpper;
        this.healthUpper = healthUpper;
        this.damage = damage;
        this.range = range;
    }

    public void GetHurt(float damage)
    {
        this.health -= damage;
    }

    public bool IsDead()
    {
        return health <= 0;
    }

    public float AttackDamage(Vector2 targetPosition)
    {
        if (Vector2.Distance(transform.position, targetPosition) <= range) 
        {
            return damage;
        }

        return 0;
    }

}