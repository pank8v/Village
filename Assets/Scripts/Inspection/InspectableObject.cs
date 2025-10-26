using System;
using Unity.VisualScripting;
using UnityEngine;

public class InspectableObject : MonoBehaviour, IInteractable
{
    public event Action<bool> OnStateChange;

    public void Interact(IInteractor interactor) {
        var inspector = interactor as IInspector;
        if (inspector != null) {
            inspector.InspectObject(gameObject);
        }
    }

    public void UpdateUI(bool state) {
        OnStateChange?.Invoke(state);
    }
    
}
