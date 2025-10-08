using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private CharacterController characterController;

    [SerializeField] private float jumpHeight = 4f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float sprintMultiplier = 1.5f;
    [SerializeField] private float movementSmoothing = 0.5f;
    [SerializeField] private float gravity = -20f;
    private float targetSpeed;
    private Vector3 horizontalMoveDirection;

    private float verticalVelocity;

    private bool isJumping = false;

    private void OnEnable() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update() {
        HandleMovement();
    }
    
    private void HandleMovement() {
        targetSpeed = inputHandler.isSprinting ? speed * sprintMultiplier : speed;
        Vector3 targetDirection = new Vector3(inputHandler.movementInput.x, 0, inputHandler.movementInput.y);
        targetDirection = transform.TransformDirection(targetDirection) * targetSpeed;
        horizontalMoveDirection = Vector3.Lerp(horizontalMoveDirection, targetDirection, movementSmoothing * Time.deltaTime);

        
    
        if (characterController.isGrounded && inputHandler.isJumping) {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (characterController.isGrounded && verticalVelocity < -0f) {
            verticalVelocity = -2f;
        }
        
        
        verticalVelocity += gravity * Time.deltaTime;
        Vector3 verticalMoveDirection = Vector3.up * verticalVelocity;
        
        
        characterController.Move((horizontalMoveDirection + verticalMoveDirection) * Time.deltaTime);
    }
  


}
