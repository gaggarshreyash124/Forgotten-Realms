using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{

    protected FiniteStateMachine StateMachine;
    protected Entity entity;
    protected EnemyData enemyData;

    protected float StartTime;

    protected string Animboolname;

    public State(Entity entity, FiniteStateMachine stateMachine, string animboolname, EnemyData enemyData)
    {
        this.entity = entity;
        StateMachine = stateMachine;
        Animboolname = animboolname;
        this.enemyData = enemyData;
    }

    public virtual void Enter()
    {
        StartTime = Time.time;
        entity.anim.SetBool(Animboolname, true);
        DoChecks();
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(Animboolname, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }
}
