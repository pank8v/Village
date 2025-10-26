using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] private GameObject Item;
    void Start() {
        mainCam = Camera.main;
    }
    
    void LateUpdate()
    {
       Vector3 lookDir = transform.position - mainCam.transform.position;
        transform.rotation = Quaternion.LookRotation(lookDir);
    }
}
