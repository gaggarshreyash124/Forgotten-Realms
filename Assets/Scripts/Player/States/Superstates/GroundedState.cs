using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : PlayerState
{

    protected int XInput;

    private bool JumpInput;
    public bool IsGrounded;

    public GroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void Dochecks()
    {
        base.Dochecks();

        player.CheckGround();
    }

    public override void Enter()
    {
        base.Enter();

        player.jumpState.ResetJumps();
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        XInput = player.InputHandler.NormalizedInputX;
        JumpInput = player.InputHandler.JumpInput;

        if (JumpInput && player.jumpState.CanJump())
        {
            player.InputHandler.UseJumpInput();
            stateMachine.ChangeState(player.jumpState);
        }
        else if (!IsGrounded)
        {
            player.inairState.startcyotetime();
            stateMachine.ChangeState(player.inairState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
