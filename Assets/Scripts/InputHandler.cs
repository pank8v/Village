using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputHandler : MonoBehaviour
{
    private InputSystem_Actions inputSystemActions;
    public Vector2 movementInput { get; private set; }
    public Vector2 lookInput { get; private set; }
    public bool isSprinting { get; private set; }

    public bool isJumping { get; private set; }
    
    private void Awake() {
        inputSystemActions = new InputSystem_Actions();
        inputSystemActions.Enable();
        inputSystemActions.Player.Move.performed += OnMovePerformed;
        inputSystemActions.Player.Move.canceled += OnMoveCanceled;
        inputSystemActions.Player.Sprint.performed += OnSprintPerformed;
        inputSystemActions.Player.Sprint.canceled += OnSprintCanceled;
        inputSystemActions.Player.Look.performed += OnLookPerformed;
        inputSystemActions.Player.Look.canceled += OnLookCanceled;
        inputSystemActions.Player.Jump.performed += OnJumpPerformed;
        inputSystemActions.Player.Jump.canceled += OnJumpCanceled;

    }


    private void OnMovePerformed(InputAction.CallbackContext ctx) {
        movementInput = ctx.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext ctx) {
        movementInput = Vector2.zero;
    }
    
    private void OnLookPerformed(InputAction.CallbackContext ctx) {
        lookInput = ctx.ReadValue<Vector2>();
    }

    private void OnLookCanceled(InputAction.CallbackContext ctx) {
        lookInput = Vector2.zero;
    }


    private void OnSprintPerformed(InputAction.CallbackContext ctx) {
        isSprinting = true;
    }

    private void OnSprintCanceled(InputAction.CallbackContext ctx) {
        isSprinting = false;
    }
    
    private void OnJumpPerformed(InputAction.CallbackContext ctx) {
        isJumping = true;
    }
    
    private void OnJumpCanceled(InputAction.CallbackContext ctx) {
        isJumping = false;
    }
}
