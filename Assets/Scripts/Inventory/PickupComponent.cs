
using UnityEngine;
using System;

public class PickupComponent : MonoBehaviour, IInteractable
{
    private IUser user;
    private IInteractor interactor;
    private IItem item;
    [SerializeField] private bool isInspectable;
    public bool IsInspectable => isInspectable;
    public event Action OnInteract;
    

    private void Awake() {
        item = GetComponent<IItem>();
    }
    
    public void Use(Transform raycastPosition) {
        item.Use(raycastPosition);
    }
    
    public void Interact(IInteractor interactor) {
        if (isInspectable) {
            interactor.ObjectInspector.StartInspection(gameObject);
        }
        else {
            if (interactor != null) { 
                this.interactor = interactor;
                AddItem();
                OnInteract?.Invoke();
            } 
        }
       
    }
    private void AddItem() {
        user = (interactor as IUser);
        if (user != null) {
            user.TryAddItem(item);
        }
    }

}
