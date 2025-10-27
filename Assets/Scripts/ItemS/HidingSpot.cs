using UnityEngine;

public class HidingSpot : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform hidingPoint;
    public void Interact(IInteractor interactor) {
     interactor.Hide(hidingPoint); 
    }
}
