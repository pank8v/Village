using UnityEngine;

public class Radio : MonoBehaviour, IItem, IInteractable
{
    [SerializeField] private ItemSO itemSO;
    private IInteractor interactor;
    private IUser user;
    
    public GameObject GameObject => gameObject;
    public ItemSO ItemSO => itemSO;
    
    public void Interact(IInteractor interactor) {
        if (interactor != null) {
            this.interactor = interactor;
            AddItem();
        }
    }
    
    public void Use(Transform _) {
        Debug.Log("Radio enabled");
    }
    
    private void AddItem() {
        user = (interactor as IUser);
        if (user != null) {
            user.InventoryComponent.AddItem(this.GameObject);
        }
    }
}
