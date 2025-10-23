using UnityEngine;
using System;
public class ObjectInteractable : MonoBehaviour, IInteractable
{
    public bool IsInspectable => isInspectable;

    private bool isInspectable = false;
    public event Action OnInteract;
    public void Interact(IInteractor interactor) {
        
    }
}
