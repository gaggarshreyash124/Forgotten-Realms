using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    
    public Vector2 RawMovementInput {get; private set;}
    public int NormalizedInputX {get; private set;}
    public int NormalizedInputY {get; private set;}

    public void OnMoveInput(InputAction.CallbackContext context)
    {

        RawMovementInput = context.ReadValue<Vector2>();
        NormalizedInputX = (int)(RawMovementInput.x * Vector2.right).normalized.x;
        NormalizedInputY = (int)(RawMovementInput.y * Vector2.up).normalized.y;

    }
    
    public void OnjumpInput(InputAction.CallbackContext context)
    {
        
    }
    
}
