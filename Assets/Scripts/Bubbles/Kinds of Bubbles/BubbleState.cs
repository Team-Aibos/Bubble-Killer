using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleState
{
    protected BubbleStateMachine stateMachine;
    protected Bubble bubble;

    protected Rigidbody2D rb;

    private string animBoolName;

    public BubbleState(Bubble _bubble, BubbleStateMachine _stateMachine, string animBoolName)
    {
        this.bubble = _bubble;
        this.stateMachine = _stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        bubble.anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
       
    }

    public virtual void Exit()
    {
       bubble.anim.SetBool(animBoolName, false);
    }
}