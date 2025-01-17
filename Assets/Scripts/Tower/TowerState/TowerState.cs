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
        Collider2D[] enemies = Physics2D.OverlapCircleAll(tower.transform.position, tower.GetRange());
        if (enemies.Length > 0)
        {
            return enemies[0].transform;
        }

        return null;
    }
}
