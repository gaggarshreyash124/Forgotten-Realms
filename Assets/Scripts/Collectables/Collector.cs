using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Icollectable collectable = collision.GetComponent<Icollectable>();

        if (collectable != null)
        {
            collectable.collect();
        }
    }
}
