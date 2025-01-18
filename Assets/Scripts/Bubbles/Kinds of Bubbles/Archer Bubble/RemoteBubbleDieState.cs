using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteBubbleDieState : BubbleState
{
    public RemoteBubble remoteBubble;

    public RemoteBubbleDieState(RemoteBubble _remoteBubble, BubbleStateMachine _stateMachine, string animBoolName)
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
        UnityEngine.Object.Destroy(remoteBubble.gameObject);
    }

    public override void Update()
    {
        base.Update();
    }
}
