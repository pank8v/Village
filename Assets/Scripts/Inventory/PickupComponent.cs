
using UnityEngine;
using System;

public class PickupComponent : MonoBehaviour, IInteractable
{
    private IUser user;
    private IInteractor interactor;
    private IItem item;
    
    

    private void Awake() {
        item = GetComponent<IItem>();
    }
    
    public void Use(Transform raycastPosition) {
        item.Use(raycastPosition, user);
    }
    
    public void Interact(IInteractor interactor) {
            if (interactor != null) { 
                this.interactor = interactor;
                AddItem();
            } 
       
    }
    private void AddItem() {
        user = (interactor as IUser);
        if (user != null) {
            user.TryAddItem(item);
        }
    }

}
