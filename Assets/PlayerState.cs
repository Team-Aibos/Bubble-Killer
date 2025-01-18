using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    protected Rigidbody2D rb;

    protected float xInput;
    protected float yInput;
    private string animBoolName;

    protected float dashTimeLeft;//≥Â∑Ê £”‡ ±º‰

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        //player.animator.SetBool(animBoolName, true);
        rb = player.rb;
    }

    public virtual void Exit()
    {
        //player.animator.SetBool(animBoolName, false);
    }

    public virtual void Update()
    {
        player.lastDash += Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

    }

}