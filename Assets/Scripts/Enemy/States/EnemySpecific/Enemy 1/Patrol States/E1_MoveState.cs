using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : MoveState
{
    Enemy1 Enemy;
    public E1_MoveState(Entity entity, FiniteStateMachine stateMachine, string Animboolname, EnemyData enemyData, Enemy1 enemy) : base(entity, stateMachine, Animboolname, enemyData)
    {
        
    }

    
}
