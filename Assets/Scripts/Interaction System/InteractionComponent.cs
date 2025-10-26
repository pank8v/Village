using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class InteractionComponent : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float interactRange = 4f;
    [SerializeField] private LayerMask detectionLayerMask;
    
    private IInteractor interactor;
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
        Ray ray = new Ray(mainCamera.position, mainCamera.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange)) {
            if (hit.collider.TryGetComponent<IInteractable>(out IInteractable interactable)) {
                currentInteractable = interactable;
            }
        }
    }


    private void Interact() {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.forward, out hit, interactRange,~0, QueryTriggerInteraction.Ignore)) {
            if (hit.collider.TryGetComponent<IInteractable>(out var interactable)) {
                interactable.Interact(interactor);
            }
        }
    }
}
