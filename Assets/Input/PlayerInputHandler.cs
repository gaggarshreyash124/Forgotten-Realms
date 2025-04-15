using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    
    public void OnMoveInput(InputAction.CallbackContext context)
    {

    }
    
    public void OnjumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            
        }

        if (context.performed)
        {

        }

        if (context.canceled)
        {
            
        }
    }
    
}
