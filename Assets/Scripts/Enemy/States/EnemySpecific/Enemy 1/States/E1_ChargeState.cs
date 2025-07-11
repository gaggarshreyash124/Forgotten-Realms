using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_ChargeState : ChargeState
{
    private Enemy1 enemy;

    public E1_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animboolname, EnemyData enemyData, Enemy1 enemy) : base(entity, stateMachine, animboolname, enemyData)
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

        if (isChargeTimeOver)
        {
            if (isPlayerinMinAgroRange)
            {
                StateMachine.ChangeState(enemy.PlayerDetectedState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }

    public override void DoChecks()
    {
        base.DoChecks();

    }
}
