using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine {get; private set;}

    //States
    public PlayerIdleState idleState {get; private set;}
    public PlayerMoveState moveState {get; private set;}

    public Animator Anim {get; private set;}

    [SerializeField] PlayerData playerData;

    void Awake()
    {
        StateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        moveState = new PlayerMoveState(this, StateMachine, playerData, "move");

    }
    void Start()
    {
        //todo:Initilaze state machine
        Anim = GetComponent<Animator>();

        StateMachine.Initialize(idleState);
    }

    void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

}
