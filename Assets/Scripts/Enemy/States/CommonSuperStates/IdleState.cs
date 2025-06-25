using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

    protected bool flipafteridle;

    protected bool isidleover;
    protected float IdleTime;

    public IdleState(Entity entity, FiniteStateMachine stateMachine, string Animboolname, EnemyData enemyData) : base(entity, stateMachine, Animboolname, enemyData)
    {

    }

    override public void Enter()
    {
        base.Enter();
        entity.SetVelocity(0);
        isidleover = false;
        SetRandomIdleTime();
    }

    override public void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= StartTime + IdleTime)
        {
            isidleover = true;
        }
    }

    override public void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }

    override public void Exit()
    {
        base.Exit();
        if (flipafteridle)
        {
            entity.Flip();
        }
    }

    public void SetFlipAfterIdle(bool flip)
    {

    }

    void SetRandomIdleTime()
    {
        IdleTime = Random.Range(enemyData.MinIdleTime, enemyData.MaxIdleTime);
    }
}
