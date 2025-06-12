using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : GroundedState
{
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (XInput != 0)
        {
            stateMachine.ChangeState(player.moveState);

        }
        else if (isAnimationFinished)
        {
            stateMachine.ChangeState(player.idleState);
            
        }

        
    }
}
