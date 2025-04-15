using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : GroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }
}
