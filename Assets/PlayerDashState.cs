using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string animBoolName) : base(_player, _stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        dashTimeLeft = player.dashTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        dashTimeLeft -= Time.deltaTime;
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
            xInput = player.facingDir;//若停止dash则根据朝向dash
        player.SetVelocity(xInput * player.dashSpeed, yInput * player.dashSpeed);

        //Debug.Log("im dash" + xInput);
        //Debug.Log("time is" + dashTimeLeft);

        //ShadowPool.instance.GetFromPool();
        if (dashTimeLeft < 0) 
        {
            player.SetVelocity(0, 0);
            player.lastDash = 0;
            stateMachine.ChangeState(player.idleState);
        }
    }
}
