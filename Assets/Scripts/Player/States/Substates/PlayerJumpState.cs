using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : AbilityState
{
    int amountofjumpsleft;
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        amountofjumpsleft = playerData.amountofjumps;
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityY(playerData.jumpForce);
        isAbilityDone = true;
        amountofjumpsleft--;
        player.inairState.SetIsJumping();
    }
    public bool CanJump()
    {
        if (amountofjumpsleft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetJumps() => amountofjumpsleft = playerData.amountofjumps;

    public void DecreseJumps() => amountofjumpsleft--;

} 
