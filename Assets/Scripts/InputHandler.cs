using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Mirror;

public class InputHandler : NetworkBehaviour
{
    private PlayerInput playerInput;
    private InputSystem_Actions inputSystemActions;
    public Vector2 movementInput { get; private set; }
    public Vector2 lookInput { get; private set; }
    public bool isSprinting { get; private set; }

    public bool isJumping { get; private set; }

    public event Action OnInteractTriggered;
    public event Action OnAttackTriggered;
    
    
    private void Awake() {
     //   inputSystemActions = new InputSystem_Actions();
     //   if(!isLocalPlayer) return;
     //   BindActions();
      //  playerInput = GetComponent<PlayerInput>();
     //   if (!isLocalPlayer) {
       //     playerInput.actions = inputSystemActions.asset;
            
     //   }
    }
    

    private void BindActions() {
      //  inputSystemActions.Player.Move.performed += OnMovePerformed;
         //inputSystemActions.Player.Move.canceled += OnMoveCanceled;
        inputSystemActions.Player.Sprint.performed += OnSprintPerformed;
       // inputSystemActions.Player.Sprint.canceled += OnSprintCanceled;
        inputSystemActions.Player.Look.performed += OnLookPerformed;
      //  inputSystemActions.Player.Look.canceled += OnLookCanceled;
        inputSystemActions.Player.Jump.performed += OnJumpPerformed;
    //    inputSystemActions.Player.Jump.canceled += OnJumpCanceled;
        inputSystemActions.Player.Interact.performed += OnInteractionPerformed;
        inputSystemActions.Player.Attack.performed += OnAttackPerformed;
    }
    
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
        OnInteractTriggered?.Invoke();
    }
    
    public void OnAttackPerformed(InputAction.CallbackContext ctx) {
        if (!isLocalPlayer) return;
        OnAttackTriggered?.Invoke();
    }
}
