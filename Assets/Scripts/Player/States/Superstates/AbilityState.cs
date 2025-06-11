using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityState : PlayerState
{
    protected bool isAbilityDone;
    bool isGrounded;
    public AbilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        isAbilityDone = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    { 
        base.LogicUpdate();

        if (isAbilityDone)
        {
            if (isGrounded && player.CurrentVelocity.y < 0.01f)
            {
                stateMachine.ChangeState(player.idleState);
            }
            else
            {
                stateMachine.ChangeState(player.inairState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
