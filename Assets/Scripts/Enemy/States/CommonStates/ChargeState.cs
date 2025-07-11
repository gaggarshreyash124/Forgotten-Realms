using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : State
{
    protected bool isPlayerinMinAgroRange;
    protected bool isChargeTimeOver;

    protected bool isLedgeDetected;
    protected bool isWallDetected;

    public ChargeState(Entity entity, FiniteStateMachine stateMachine, string animboolname, EnemyData enemyData) : base(entity, stateMachine, animboolname, enemyData)
    {

    }

    public override void Enter()
    {
        base.Enter();

        isChargeTimeOver = false;
        entity.SetVelocity(enemyData.chargeSpeed);
    }
    public override void Exit()
    {
        base.Exit();

    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= StartTime + enemyData.chargeTime)
        {
            Debug.Log("Charge Time Over");
            isChargeTimeOver = true;
        }



    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();


    }
    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerinMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isLedgeDetected = entity.CheckLedge();
        isWallDetected = entity.CheckWall();
    }

}
