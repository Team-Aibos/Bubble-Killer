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
        UnityEngine.Object.Destroy(remoteBubble.gameObject, 0.75f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (remoteBubble.isDead)
        {
            remoteBubble.anim.SetTrigger("RemoteBubbleDie Final");
            
        }
    }
}
