using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunState{
    protected GunStateMachine stateMachine;
    protected Gun gun;
  
    private string animBoolName;

    public GunState(Gun _gun, GunStateMachine _stateMachine, string animBoolName)
    {
        this.gun = _gun;
        this.stateMachine = _stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        gun.animator.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        gun.animator.SetBool(animBoolName, false);
    }

    public virtual void Update()
    {
        
    }
}