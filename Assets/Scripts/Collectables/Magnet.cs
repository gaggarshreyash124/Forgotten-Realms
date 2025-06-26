using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Attractable attractable = collision.GetComponent<Attractable>();

        if (attractable != null)
        {
            attractable.target = transform;
        }
    }
}
