using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using System;

public class Coin : MonoBehaviour, Icollectable
{
    public static event Action OnCoinCollected;
    public void collect()
    {
        OnCoinCollected?.Invoke();
        Debug.Log("Coin Collected!");
        Destroy(gameObject);
    }
}
