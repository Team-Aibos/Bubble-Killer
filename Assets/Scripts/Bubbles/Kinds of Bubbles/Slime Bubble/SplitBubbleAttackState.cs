using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBubbleAttackState : BubbleState
{
    public SplitBubble splitBubble;

    public SplitBubbleAttackState(SplitBubble _splitBubble, BubbleStateMachine _stateMachine, string animBoolName)
       : base(_splitBubble, _stateMachine, animBoolName)
    {
        splitBubble = _splitBubble;
    }
}
