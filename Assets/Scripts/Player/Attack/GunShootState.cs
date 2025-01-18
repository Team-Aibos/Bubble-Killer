using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootState : GunState
{
    public GunShootState(Gun _gun, GunStateMachine _stateMachine, string animBoolName) : base(_gun, _stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
