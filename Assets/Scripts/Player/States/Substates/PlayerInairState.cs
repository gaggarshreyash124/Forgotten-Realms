using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInairState : PlayerState
{
    private bool isGrounded;
    private int Xinput;
    bool JumpInput;
    bool CyoteTime;

    public bool isJumping;
    bool JumpInputStop;

    public PlayerInairState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Dochecks()
    {
        base.Dochecks();

        isGrounded = player.CheckGround();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


        CheckCoyoteTime();

        Xinput = player.InputHandler.NormalizedInputX;
        JumpInput = player.InputHandler.JumpInput;
        JumpInputStop = player.InputHandler.JumpInputStop;


        if (isGrounded && player.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.landState);
            player.Createdust();
        }
        else if (JumpInput && player.jumpState.CanJump())
        {
            stateMachine.ChangeState(player.jumpState);
        }
        else
        {
            player.CheckFlip(Xinput,false);
            player.SetVelocityX(playerData.moveSpeed * Xinput);

            player.Anim.SetFloat("Yvelocity", player.CurrentVelocity.y);
            player.Anim.SetFloat("Xvelocity", Mathf.Abs(player.CurrentVelocity.x));
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    void CheckCoyoteTime()
    {
        if (CyoteTime && Time.time > startTime + playerData.cyotetime)
        {
             CyoteTime = false;
            player.jumpState.DecreseJumps();
        }
    }
    public void startcyotetime() => CyoteTime = true;

    public void SetIsJumping() => isJumping = true;
}
