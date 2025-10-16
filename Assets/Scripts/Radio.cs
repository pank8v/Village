using UnityEngine;

public class Radio : MonoBehaviour, IItem, IInteractable
{
    [SerializeField] private ItemSO itemSO;
    private IInteractor interactor;
    
    public ItemSO ItemSO => itemSO;
    
    public void Interact(IInteractor interactor) {
        this.interactor = interactor;
        AddItem();
    }
    
    
    public void Use() {
        Debug.Log("Radio enabled");
    }
    public GameObject GameObject => this.GameObject;

    private void AddItem() {
        if (interactor != null) {
            interactor.InventoryComponent.AddItem(this);
            Debug.Log("Item added");
        }
    }
    
}
