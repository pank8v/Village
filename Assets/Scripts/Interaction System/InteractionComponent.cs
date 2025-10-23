using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class InteractionComponent : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Transform interactorTransform;
    [SerializeField] private float detectionRadius = 2f;
    [SerializeField] private float maxViewAngle = 90f;
    [SerializeField] private LayerMask detectionLayerMask;
    
    private IInteractor interactor;
    private IInteractable lastInteractable;
    private IInteractable currentInteractable;

    private void Awake() {
        interactor = GetComponent<IInteractor>();
    }
    
    private void OnEnable() {
        interactor.OnInteract += Interact;
    }

    private void OnDisable() {
        interactor.OnInteract -= Interact;
    }
    
    private void Update() {
        FindInteractableObjects();
    }
    

    private void FindInteractableObjects() {
        currentInteractable = null;
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayerMask);
        float minDistance = Mathf.Infinity;
        for (int i = 0; i < hits.Length; i++) {
            IInteractable interactable = hits[i].GetComponent<IInteractable>();
            if (interactable == null) {
                continue;
            }
            Vector3 closestPoint = hits[i].ClosestPoint(transform.position);
            Vector3 dirToObject = (closestPoint - interactorTransform.position).normalized;
            float angle = Vector3.Angle(interactorTransform.forward, dirToObject);
            if (angle > maxViewAngle/2) {
                continue;
            }
            float distance = Vector3.Distance(interactorTransform.position, closestPoint);
            if (distance < minDistance) {
                minDistance = distance;
                currentInteractable = interactable;
            }
        }
    }


    private void Interact() {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.forward, out hit, 2f)) {
            if (hit.collider.TryGetComponent<IInteractable>(out var interactable)) {
                interactable.Interact(interactor);
            }
        }
     //   if (currentInteractable != null) {
       //     currentInteractable.Interact(interactor);
       // }
    }
}
