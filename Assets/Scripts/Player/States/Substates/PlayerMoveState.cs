using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : GroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }
}
