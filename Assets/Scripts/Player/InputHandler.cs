using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Mirror;

public class InputHandler : NetworkBehaviour
{
    private PlayerInput playerInput;
    public Vector2 movementInput { get; private set; }
    public Vector2 lookInput { get; private set; }
    public bool isSprinting { get; private set; }

    public bool isJumping { get; private set; }

    public event Action OnInteractTriggered;
    public event Action OnAttackTriggered;
    public event Action OnDropTriggered;
    
    
    public void OnMovementPerformed(InputAction.CallbackContext ctx) {
        if (!isLocalPlayer) return;
        movementInput = ctx.ReadValue<Vector2>();
    }
    
    public void OnLookPerformed(InputAction.CallbackContext ctx) {
        if (!isLocalPlayer) return;
        lookInput = ctx.ReadValue<Vector2>();
    }
    
    public void OnSprintPerformed(InputAction.CallbackContext ctx) {
        if (!isLocalPlayer) return;
        isSprinting = ctx.action.triggered;
    }
    
    public void OnJumpPerformed(InputAction.CallbackContext ctx) {
        if (!isLocalPlayer) return;
        isJumping = ctx.action.triggered;
    }
    
    public void OnInteractionPerformed(InputAction.CallbackContext ctx) {
        if (!isLocalPlayer) return;
        if (!ctx.performed) return;
        OnInteractTriggered?.Invoke();
    }
    
    public void OnAttackPerformed(InputAction.CallbackContext ctx) {
        if (!isLocalPlayer) return;
        if (!ctx.performed) return;
        OnAttackTriggered?.Invoke();
    }

    public void OnDropPerformed(InputAction.CallbackContext ctx) {
        if (!isLocalPlayer) return;
        if(!ctx.performed) return;
        OnDropTriggered?.Invoke();
    }
}
