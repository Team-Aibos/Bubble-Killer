using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteBubbleAttackState : BubbleState
{
    public RemoteBubble remoteBubble;

    public RemoteBubbleAttackState(RemoteBubble _remoteBubble, BubbleStateMachine _stateMachine, string animBoolName)
        : base(_remoteBubble, _stateMachine, animBoolName)
    {
        remoteBubble = _remoteBubble;
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
