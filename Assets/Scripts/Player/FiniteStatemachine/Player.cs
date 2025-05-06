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
    public Rigidbody2D rb {get; private set;}
    public PlayerInputHandler InputHandler {get; private set;}


    [SerializeField] PlayerData playerData;

    private Vector2 workspace;
    public Vector2 CurrentVelocity {get; private set;}

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
        InputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();

        StateMachine.Initialize(idleState);
    }

    void Update()
    {
        CurrentVelocity = rb.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    public void SetVelocityX(float Velocity)
    {
        workspace.Set(Velocity, CurrentVelocity.y);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

}
