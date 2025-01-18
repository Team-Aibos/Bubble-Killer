using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerState
{
    #region StateInit
    protected Tower tower;
    protected TowerStateMachine stateMachine;
    private string stateName;
    #endregion

    public TowerState(Tower tower, TowerStateMachine stateMachine, string stateName)
    {
        this.tower = tower;
        this.stateMachine = stateMachine;
        this.stateName = stateName;
    }

    public virtual void Enter()
    {

    }

    public virtual void Update()    
    {

    }

    public virtual void Exit()
    {

    }

    public Transform FindEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(tower.transform.position, tower.GetRange(), LayerMask.GetMask("Enemy"));
        if (enemies.Length > 0)
        {
            Collider2D closestEnemy = enemies[0];
            for (int i = 1; i < enemies.Length; i++)
            {
                if (Vector2.Distance(tower.transform.position, enemies[i].transform.position) < Vector2.Distance(tower.transform.position, closestEnemy.transform.position))
                {
                    closestEnemy = enemies[i];
                }
            }
            return closestEnemy.transform;
        }

        return null;
    }
}
