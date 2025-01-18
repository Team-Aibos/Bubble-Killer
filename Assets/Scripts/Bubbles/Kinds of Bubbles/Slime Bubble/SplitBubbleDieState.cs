using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBubbleDieState : BubbleState
{
    public SplitBubble splitBubble;

    public SplitBubbleDieState(SplitBubble _splitBubble, BubbleStateMachine _stateMachine, string animBoolName)
       : base(_splitBubble, _stateMachine, animBoolName)
    {
        splitBubble = _splitBubble;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        UnityEngine.Object.Destroy(splitBubble.gameObject);
    }

    public override void Update()
    {
        base.Update();
    }
}
