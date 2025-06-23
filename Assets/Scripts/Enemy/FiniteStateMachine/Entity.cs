using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }

    public GameObject Alive { get; private set; }
    
    public virtual void Start()
    {
        Alive = transform.Find("Alive").gameObject;
        rb = Alive.GetComponent<Rigidbody2D>();
        anim = Alive.GetComponent<Animator>();

    } 

}