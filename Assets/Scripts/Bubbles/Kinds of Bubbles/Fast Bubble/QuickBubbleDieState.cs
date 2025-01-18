using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickBubbleDieState : BubbleState
{
    public QuickBubble quickBubble;

    public QuickBubbleDieState(QuickBubble _quickBubble, BubbleStateMachine _stateMachine, string animBoolName)
       : base(_quickBubble, _stateMachine, animBoolName)
    {
        quickBubble = _quickBubble;
    }
}
