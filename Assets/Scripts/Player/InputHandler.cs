using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    public Vector2 movementInput { get; private set; }
    public Vector2 lookInput { get; private set; }
    public bool isSprinting { get; private set; }

    public bool isJumping { get; private set; }

    public event Action OnInteractTriggered;
    public event Action OnAttackTriggered;
    public event Action OnDropTriggered;
    public event Action<int> OnItemSwitch;
    public event Action OnReload;
    
    
    public void OnMovementPerformed(InputAction.CallbackContext ctx) {
        movementInput = ctx.ReadValue<Vector2>();
    }
    
    public void OnLookPerformed(InputAction.CallbackContext ctx) {
        lookInput = ctx.ReadValue<Vector2>();
    }
    
    public void OnSprintPerformed(InputAction.CallbackContext ctx) {
        isSprinting = ctx.action.triggered;
    }
    
    public void OnJumpPerformed(InputAction.CallbackContext ctx) {
        isJumping = ctx.action.triggered;
    }
    
    public void OnInteractionPerformed(InputAction.CallbackContext ctx) {
        if (!ctx.performed) return;
        OnInteractTriggered?.Invoke();
    }
    
    public void OnAttackPerformed(InputAction.CallbackContext ctx) {
        if (!ctx.performed) return;
        OnAttackTriggered?.Invoke();
    }

    public void OnDropPerformed(InputAction.CallbackContext ctx) {
        if(!ctx.performed) return;
        OnDropTriggered?.Invoke();
    }

    public void OnFirstItemSwitchPerformed(InputAction.CallbackContext ctx) {
        if (!ctx.performed) return;
        OnItemSwitch?.Invoke(0);
    }
    
    public void OnSecondItemSwitchPerformed(InputAction.CallbackContext ctx) {
        if (!ctx.performed) return;
        OnItemSwitch?.Invoke(1);
    }

    public void OnReloadPerformed(InputAction.CallbackContext ctx) {
        if (!ctx.performed) return;
        OnReload?.Invoke();
    }
}
