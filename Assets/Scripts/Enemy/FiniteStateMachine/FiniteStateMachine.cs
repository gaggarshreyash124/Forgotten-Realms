using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
    public State CurrentState { get; private set; }

    public void Initilize(State StartState)
    {
        CurrentState = StartState;
        CurrentState.Enter();               
    }

    public void ChangeState(State newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

}
