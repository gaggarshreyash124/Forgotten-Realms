using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("MoveState")]
    public float moveSpeed = 5f;

    [Header("JumpState")]
    public float jumpForce = 15f;
    public int amountofjumps = 1;

    [Header("Check Variables")]
    public float GroundCheckRadius = 0.3f;
    public LayerMask GroundMask;
}
