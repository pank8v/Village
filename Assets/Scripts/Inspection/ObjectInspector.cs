using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInspector : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private Transform inspectObject;
    private GameObject objectToInspect;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float minDistance = 0.35f;
    [SerializeField] private float maxDistance = 1f;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isInspecting = false;
    private Vector2 rotateInput;
    private float currentDistance = 1f;
    [SerializeField] private float zoomSpeed = 1f;
    private void Awake() {
        playerInput = GetComponent<PlayerInput>();
    }
    
    public void StartInspection(GameObject newObject){        
        originalPosition = newObject.transform.position;
        originalRotation = newObject.transform.rotation;
        
        if (playerInput != null) {
            playerInput.SwitchCurrentActionMap("Inspector");
        }

        
        objectToInspect = newObject;
        objectToInspect.transform.SetParent(inspectObject);
        inspectObject.transform.localRotation = Quaternion.identity;
        objectToInspect.transform.localPosition = Vector3.zero;
        objectToInspect.transform.localRotation = Quaternion.identity;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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


    public void OnZoom(InputAction.CallbackContext ctx) {
        float scroll = ctx.ReadValue<Vector2>().y;
        currentDistance = Mathf.Clamp(currentDistance + scroll * zoomSpeed * Time.deltaTime, minDistance, maxDistance);
        inspectObject.localPosition = new Vector3(0, 0, currentDistance);
    }
    
    private void Update() {
        if (!isInspecting) return;
        float rotX = -rotateInput.x * rotationSpeed * Time.deltaTime;
        float rotY = -rotateInput.y * rotationSpeed * Time.deltaTime;
        inspectObject.Rotate(Vector3.up, rotX, Space.World);
        inspectObject.Rotate(Vector3.right, rotY, Space.World);
    }

    public void FinishInspection(InputAction.CallbackContext ctx) {
        objectToInspect.transform.position = originalPosition;
        objectToInspect.transform.rotation = originalRotation;
        objectToInspect.transform.SetParent(null);
        isInspecting = false;
        playerInput.SwitchCurrentActionMap("Player");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
