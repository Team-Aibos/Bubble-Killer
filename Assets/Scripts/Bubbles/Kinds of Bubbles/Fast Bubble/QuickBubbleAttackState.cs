using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickBubbleAttackState : BubbleState
{
    public QuickBubble quickBubble;

    public QuickBubbleAttackState(QuickBubble _quickBubble, BubbleStateMachine _stateMachine, string animBoolName)
       : base(_quickBubble, _stateMachine, animBoolName)
    {
        quickBubble = _quickBubble;
    }

    public override void Enter()
    {
        base.Enter();
        UnityEngine.Object.Destroy(quickBubble.gameObject, .8f);
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
