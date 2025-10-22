using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInspector : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private Transform inspectObject;

    private bool isInspecting = false;
    private Vector2 rotateInput;
    
    private void Start() {
        playerInput = GetComponent<PlayerInput>();
        if (playerInput != null) {
            playerInput.SwitchCurrentActionMap("Inspector");
        }
    }


    public void OnInspect(InputAction.CallbackContext ctx) {
        if (ctx.started) {
            isInspecting = true;
        }else if (ctx.canceled) {
            isInspecting = false;
        }
    }

    public void OnRotate(InputAction.CallbackContext ctx) {
        rotateInput = ctx.ReadValue<Vector2>();
    }


    private void Update() {
        if (!isInspecting) return;
        float rotX = -rotateInput.x * 10f * Time.deltaTime;
        float rotY = rotateInput.y * 10f * Time.deltaTime;
        inspectObject.Rotate(Vector3.up, rotX, Space.World);
        inspectObject.Rotate(Vector3.right, rotY, Space.World);
    }
    
}
