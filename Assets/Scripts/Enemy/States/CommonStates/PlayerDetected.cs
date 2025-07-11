using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : State
{

    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;

    protected bool performLongRangeAction;

    public PlayerDetected(Entity entity, FiniteStateMachine stateMachine, string animboolname, EnemyData enemyData) : base(entity, stateMachine, animboolname, enemyData)
    {

    }

    public override void Enter()
    {
        base.Enter();

        performLongRangeAction = false;
        entity.SetVelocity(0);


    }
    public override void Exit()
    {
        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= StartTime + enemyData.LongRangeActionTime)
        {
            performLongRangeAction = true;
        }
        
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
    }
}
