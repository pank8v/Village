using Unity.VisualScripting;
using UnityEngine;

public class InspectableObject : MonoBehaviour, IInteractable
{
    public void Interact(IInteractor interactor) {
        var inspector = interactor as IInspector;
        if (inspector != null) {
            inspector.InspectObject(gameObject);
        }
    }
}
