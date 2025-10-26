using System;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string itemId;

    [SerializeField] private Rigidbody _rb;
    public void Interact(IInteractor interactor) {
        if (interactor.CheckRequiredItem(itemId)) {
            _rb.isKinematic = false;
        }
        else {
            Debug.Log("door requires key");
        }
    }
    
}
