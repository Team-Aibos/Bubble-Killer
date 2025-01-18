using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBubbleAttackState : BubbleState
{
    public CommonBubble commonBubble;

    public CommonBubbleAttackState(CommonBubble _commonBubble, BubbleStateMachine _stateMachine, string animBoolName)
        : base(_commonBubble, _stateMachine, animBoolName)
    {
        commonBubble = _commonBubble;
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
