using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine { get; private set; }
    public EnemyData enemyData { get; set; }

    public int facingDirection = 1;

    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }

    public GameObject Alive { get; private set; }

    private Vector2 VelocityWorkspace;

    [SerializeField] Transform wallCheck;
    [SerializeField] Transform ledgeCheck;
    [SerializeField] Transform PlayerCheck;

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
        Alive.transform.Rotate(0f, 180f, 0f);

    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(PlayerCheck.transform.position, Alive.transform.right, enemyData.minAgroDistance, enemyData.Player);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(PlayerCheck.transform.position, Alive.transform.right, enemyData.maxAgroDistance, enemyData.Player);
    }

}