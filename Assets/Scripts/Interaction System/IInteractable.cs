using UnityEngine;
using System;
public interface IInteractable
{
    public bool IsInspectable { get; }
    public void Interact(IInteractor interactor);
}
