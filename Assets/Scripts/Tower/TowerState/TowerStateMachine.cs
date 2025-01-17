using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStateMachine
{
    public TowerState currentState { get; private set; }

    public void InitialState(TowerState state)
    {
        currentState = state;
        currentState.Enter();
    }
    
    public void ChangeState(TowerState newstate)
    {
        currentState.Exit();
        currentState = newstate;
        currentState.Enter();
    }
}
