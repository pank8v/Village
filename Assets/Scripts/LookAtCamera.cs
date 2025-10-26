using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;

    private void Start() {
        mainCamera = Camera.main;
    }
    
    
    private void Update() {
        transform.LookAt(mainCamera.transform);
        transform.Rotate(offsetX, offsetY, offsetZ);
    }
}
