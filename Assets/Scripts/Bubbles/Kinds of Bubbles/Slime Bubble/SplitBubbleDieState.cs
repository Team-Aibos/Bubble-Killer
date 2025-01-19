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
        UnityEngine.Object.Destroy(splitBubble.gameObject, 0.75f);
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
