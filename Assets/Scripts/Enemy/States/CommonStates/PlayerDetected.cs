using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : State
{

    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;

    public PlayerDetected(Entity entity, FiniteStateMachine stateMachine, string animboolname, EnemyData enemyData) : base(entity, stateMachine, animboolname, enemyData)
    {

    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0);
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
        
    }
    public override void Exit()
    {
        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
    }
}
