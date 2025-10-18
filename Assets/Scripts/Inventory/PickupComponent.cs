using UnityEditor;
using UnityEngine;

public class PickupComponent : MonoBehaviour, IInteractable
{
  //  private GameObject itemPrefab;
    private IUser user;
    private IInteractor interactor;
    private IItem item;
    

    private void Awake() {
    //    itemPrefab = this.gameObject;
        item = GetComponent<IItem>();
    }
    
    public void Use(Transform raycastPosition) {
        item.Use(raycastPosition);
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
            user.InventoryComponent.AddItem(item);
        }
    }

}
