using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private Rigidbody doorBody;
    public void Interact(IInteractor interactor) {
        doorBody.linearVelocity = new Vector3(0, 0, 1) * 10f;
    }
}
