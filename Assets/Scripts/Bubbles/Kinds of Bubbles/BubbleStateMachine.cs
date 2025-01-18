using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BubbleStateMachine 
{
    public BubbleState currentState { get; private set; }

    public void Initialize(BubbleState _state)
    {
        currentState = _state;
        currentState.Enter();
    }

    public void ChangeState(BubbleState _newstate)
    {
        currentState.Exit();
        currentState = _newstate;
        currentState.Enter();
    }
}
