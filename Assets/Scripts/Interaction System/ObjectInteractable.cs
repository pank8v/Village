using UnityEngine;
using System;
public class ObjectInteractable : MonoBehaviour, IInteractable
{
    public event Action OnInteract;
    public void Interact(IInteractor interactor) {
        
    }
}
