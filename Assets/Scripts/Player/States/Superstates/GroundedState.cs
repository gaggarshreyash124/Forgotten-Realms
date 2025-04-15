using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : PlayerState
{
    public GroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }
}
