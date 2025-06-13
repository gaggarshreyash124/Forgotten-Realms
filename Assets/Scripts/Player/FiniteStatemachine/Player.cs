using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }

    //States
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerInairState inairState { get; private set; }
    public PlayerLandState landState { get; private set; }

    [SerializeField] PlayerData playerData;

    #endregion

    #region Components Variables
    public Animator Anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    #endregion
    public ParticleSystem dust;

    #region Other Variables

    private Vector2 workspace;
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    #endregion

    #region Check Variables

    
    [SerializeField] private Transform GroundCheck;

    #endregion


    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        moveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        jumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        inairState = new PlayerInairState(this, StateMachine, playerData, "inAir");
        landState = new PlayerLandState(this, StateMachine, playerData, "land");

    }

    private void Start()
    {
        //todo:Initilaze state machine
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();
        FacingDirection = 1;

        StateMachine.Initialize(idleState);
        if (InputHandler != null)
        {

            Debug.Log("yaaaa");
        }
    }

    private void Update()
    {
        CurrentVelocity = rb.velocity;
        StateMachine.CurrentState.LogicUpdate();
       
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocityX(float Velocity)
    {
        workspace.Set(Velocity, CurrentVelocity.y);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    
    public void CheckFlip(int Xinput,bool MoveState)
    {
        if (Xinput != 0 && Xinput != FacingDirection && MoveState)
        {
            Flip();
            Createdust();
        }
        else if (Xinput != 0 && Xinput != FacingDirection)
        {
            Flip();
        }
    }

    public bool CheckGround()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, playerData.GroundCheckRadius, playerData.GroundMask);
    }
    private void Flip()
    {
        FacingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        dust.transform.localScale = new Vector3(dust.transform.localScale.x * -1, dust.transform.localScale.y, dust.transform.localScale.z);
    }

    public void SetVelocityY(float Velocity)
    {
        workspace.Set(CurrentVelocity.x, Velocity);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }
    public void Createdust()
    {
        dust.Play();
    }

}
  