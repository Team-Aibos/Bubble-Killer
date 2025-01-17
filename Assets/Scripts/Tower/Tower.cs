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

    #region Components
    public Animator animator { get;private set; }
    #endregion

    #region State
    public TowerStateMachine stateMachine { get; private set; }

    public TowerIdleState idleState { get; private set; }
    public TowerAttackState attackState { get; private set; }
    public TowerHurtState hurtState { get; private set; }
    public TowerDeadState deadState { get; private set; }
    #endregion

    public Tower(float healthUpper, float damage, float range)
    {
        this.health = healthUpper;
        this.healthUpper = healthUpper;
        this.damage = damage;
        this.range = range;
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