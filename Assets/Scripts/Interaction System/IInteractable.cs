using UnityEngine;
using System;
public interface IInteractable
{
    public event Action OnInteract;
    public void Interact(IInteractor interactor);
}
