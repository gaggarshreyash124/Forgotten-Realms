using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine { get; private set; }
    public EnemyData enemyData { get; set; }

    public int facingDirection  { get; private set; }

    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }

    public GameObject Alive { get; private set; }

    private Vector2 VelocityWorkspace;

    [SerializeField] Transform wallCheck;
    [SerializeField] Transform ledgeCheck;

    public virtual void Start()
    {
        Alive = transform.Find("Alive").gameObject;
        rb = Alive.GetComponent<Rigidbody2D>();
        anim = Alive.GetComponent<Animator>();

        stateMachine = new FiniteStateMachine();
    }
    public virtual void Update()
    {
        stateMachine.CurrentState.LogicUpdate();
    }
    public virtual void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float Velocity)
    {
        Debug.Log(Velocity);
        VelocityWorkspace = new Vector2(facingDirection * Velocity, rb.velocity.y);
        Debug.Log(VelocityWorkspace);
        rb.velocity = VelocityWorkspace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, Alive.transform.right, enemyData.wallCheckDistance, enemyData.Ground);
    }
    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, enemyData.ledgeCheckDistance, enemyData.Ground);
    }

    public virtual void Flip()
    {
        facingDirection *= -1;
        Alive.transform.localScale = new Vector3(Alive.transform.localScale.x * -1, Alive.transform.localScale.y, Alive.transform.localScale.z);
    }
}