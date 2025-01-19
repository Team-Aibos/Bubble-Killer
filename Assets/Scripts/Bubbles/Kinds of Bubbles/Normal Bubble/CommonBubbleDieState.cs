using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBubbleDieState : BubbleState
{
    public CommonBubble commonBubble;

    public CommonBubbleDieState(CommonBubble _commonBubble, BubbleStateMachine _stateMachine, string animBoolName)
        : base(_commonBubble, _stateMachine, animBoolName)
    {
        commonBubble = _commonBubble;
    }

    public override void Enter()
    {
        base.Enter();
        UnityEngine.Object.Destroy(commonBubble.gameObject, 0.75f);
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
