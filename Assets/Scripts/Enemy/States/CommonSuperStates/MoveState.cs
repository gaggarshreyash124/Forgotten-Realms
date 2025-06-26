using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{

    protected bool isWallthere;
    protected bool isLedgethere;

    public Enemy1 Enemy1;

    public MoveState(Entity entity, FiniteStateMachine stateMachine, string animboolname, EnemyData enemyData) : base(entity, stateMachine, animboolname, enemyData)
    {

    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(enemyData.speed);
        isWallthere = entity.CheckWall();
        isLedgethere = entity.CheckLedge();
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

        isWallthere = entity.CheckWall();
        isLedgethere = entity.CheckLedge();

        Debug.Log(isLedgethere);
        Debug.Log(isWallthere);

    }
}
