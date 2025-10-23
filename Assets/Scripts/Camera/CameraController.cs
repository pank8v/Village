
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private float mouseSensitivity = 100f;
    private float xRotation = 0f;
    
    
    private void LateUpdate() {
        HandleRotation();
    }
    
    
    private void HandleRotation() {
        Vector2 lookInput = inputHandler.lookInput;
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
