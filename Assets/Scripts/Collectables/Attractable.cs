using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractable : MonoBehaviour
{
    public Transform target;
    public float movespeed = 1f;
    void Update()
    {
        if (target)
        {
            Vector2 direction = target.position - transform.position;
            transform.Translate(direction.normalized * movespeed * Time.deltaTime);
    }
    }

}
