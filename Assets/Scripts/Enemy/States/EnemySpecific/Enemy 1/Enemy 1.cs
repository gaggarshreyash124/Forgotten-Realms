using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    [SerializeField]
    EnemyData SpecificData;

    public E1_MoveState MoveState { get; private set; }
    public E1_IdleState idleState { get; private set; }
    public E1_PlayerDetected PlayerDetectedState { get; private set; }
    public E1_ChargeState ChargeState { get; private set; }

    override public void Start()
    {
        base.Start();

        enemyData = SpecificData;

        MoveState = new E1_MoveState(this, stateMachine, "move", enemyData, this);
        idleState = new E1_IdleState(this, stateMachine, "idle", enemyData, this);
        PlayerDetectedState = new E1_PlayerDetected(this, stateMachine, "playerDetected", enemyData, this);
        ChargeState = new E1_ChargeState(this, stateMachine, "charge", enemyData, this);

        stateMachine.Initilize(MoveState);


    }
}
