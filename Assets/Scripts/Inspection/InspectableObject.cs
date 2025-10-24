using UnityEngine;

public class InspectableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isInspectable;
    public bool IsInspectable => isInspectable;
    public void Interact(IInteractor interactor) {
        interactor.ObjectInspector.StartInspection(gameObject);
    }
}
