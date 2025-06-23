using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{

    protected FiniteStateMachine StateMachine;
    protected Entity entity;

    protected float StartTime;

    protected string Animboolname;

    public State(Entity entity, FiniteStateMachine stateMachine, string Animboolname)
    {
        this.entity = entity;
        this.StateMachine = stateMachine;
        this.Animboolname = Animboolname;
    }

    public virtual void Enter()
    {
        StartTime = Time.time;
        entity.anim.SetBool(Animboolname, true);
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

    }
}
