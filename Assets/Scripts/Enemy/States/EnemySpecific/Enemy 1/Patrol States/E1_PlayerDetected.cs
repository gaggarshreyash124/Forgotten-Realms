using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_PlayerDetected : PlayerDetected
{
    Enemy1 enemy;

    public E1_PlayerDetected(Entity entity, FiniteStateMachine stateMachine, string animboolname, EnemyData enemyData, Enemy1 enemy) : base(entity, stateMachine, animboolname, enemyData)
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

        if (!isPlayerInMaxAgroRange)
        {
            enemy.idleState.SetFlipAfterIdle(false);
            enemy.stateMachine.ChangeState(enemy.idleState);
        }

    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
