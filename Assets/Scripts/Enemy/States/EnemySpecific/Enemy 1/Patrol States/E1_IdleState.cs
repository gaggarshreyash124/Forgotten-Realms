using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_IdleState : IdleState
{
    Enemy1 enemy;

    public E1_IdleState(Entity entity, FiniteStateMachine stateMachine, string Animboolname, EnemyData enemyData,Enemy1 enemy) : base(entity, stateMachine, Animboolname, enemyData)
    {
        this.enemy = enemy;
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
        if (isidleover)
        {
            StateMachine.ChangeState(enemy.MoveState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
    
