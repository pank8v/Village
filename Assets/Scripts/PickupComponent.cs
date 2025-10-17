using UnityEditor;
using UnityEngine;

public class PickupComponent : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject itemPrefab;
    private IUser user;
    private IInteractor interactor;
    private IWeapon item;
    

    private void Awake() {
        item = itemPrefab.GetComponent<IWeapon>();
    }
    
    public void Use(Transform raycastPosition) {
        item.Attack(raycastPosition);
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
            user.InventoryComponent.AddItem(itemPrefab);
        }
    }

}
