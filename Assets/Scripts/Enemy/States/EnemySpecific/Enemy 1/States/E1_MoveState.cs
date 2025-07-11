using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : MoveState
{
    Enemy1 Enemy;

    public E1_MoveState(Entity entity, FiniteStateMachine stateMachine, string Animboolname, EnemyData enemyData, Enemy1 enemy) : base(entity, stateMachine, Animboolname,enemyData)
    {
        Enemy = enemy;
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

        if (isPlayerInMinAgroRange)
        {
            Enemy.stateMachine.ChangeState(Enemy.PlayerDetectedState);
        }
        else if (!isLedgethere || isWallthere)
        {
            Enemy.idleState.SetFlipAfterIdle(true);
            StateMachine.ChangeState(Enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
    
}
