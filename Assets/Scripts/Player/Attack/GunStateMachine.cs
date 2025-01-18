using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStateMachine
{
    public GunState currentState { get; private set; }

    public void Initialize(GunState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(GunState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
