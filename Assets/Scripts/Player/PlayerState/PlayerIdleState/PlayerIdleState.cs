using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string animBoolName) : base(_player, _stateMachine, animBoolName)
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

        if (Input.GetKeyDown(KeyCode.LeftShift) && player.lastDash >= player.dashCD)
        {
            stateMachine.ChangeState(player.dashState);
        }
        else if (xInput != 0 || yInput != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }
}
