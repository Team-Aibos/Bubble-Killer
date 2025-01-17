using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDeadState : TowerState
{
    public TowerDeadState(Tower tower, TowerStateMachine stateMachine, string stateName) : base(tower, stateMachine, stateName)
    {

    }

    public override void Enter()
    {
        tower.animator.SetTrigger("Dead");
        Object.Destroy(tower.gameObject, 1.0f);    //һ���ݻٷ�����
    }

    public override void Exit()
    {
        //�����д����һ��������Ϸ�ĳ���
        base.Exit();
    }
}
