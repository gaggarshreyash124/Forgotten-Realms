using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }

    public int NormalizedInputX { get; private set; }
    public int NormalizedInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop {  get; private set; }

    [SerializeField]
    private float InputHoldTime = 0.2f;

    float JumpInputStartTime;


    private void Update()
    {
        CheckJumpInputHoldTime();
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {

        RawMovementInput = context.ReadValue<Vector2>();
        NormalizedInputX = (int)(RawMovementInput.x * Vector2.right).normalized.x;
        NormalizedInputY = (int)(RawMovementInput.y * Vector2.up).normalized.y;

        Debug.Log("HHOOOOO");

    }

    public void OnjumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            JumpInput = false;
            JumpInputStop = false;
            JumpInputStartTime = Time.time;
        }
    }

    public void UseJumpInput() => JumpInput = false;

    void CheckJumpInputHoldTime()
    {
        if (Time.time >= JumpInputStartTime + InputHoldTime)
        {
            JumpInput = false;
        }
    }
}
