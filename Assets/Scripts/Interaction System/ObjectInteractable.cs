using UnityEngine;

public class ObjectInteractable : MonoBehaviour, IInteractable
{
    public void Interact(IInteractor interactor) {
        Debug.Log("Dooooooroo");
    }
}
