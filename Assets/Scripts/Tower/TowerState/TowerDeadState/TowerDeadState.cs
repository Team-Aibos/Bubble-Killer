using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerDeadState : TowerState
{
    public TowerDeadState(Tower tower, TowerStateMachine stateMachine, string stateName) : base(tower, stateMachine, stateName)
    {

    }

    public override void Enter()
    {
        //tower.animator.SetTrigger("Dead");
        Object.Destroy(tower.gameObject, 1.0f);    //一秒后摧毁防御塔

        SceneManager.LoadScene("GameOverScene");
    }

    public override void Exit()
    {
        //这里有待添加一个结束游戏的场景
        base.Exit();
    }
}
