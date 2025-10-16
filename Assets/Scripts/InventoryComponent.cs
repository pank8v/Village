using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class InventoryComponent : MonoBehaviour
{
    [SerializeField] private Transform itemHolder;
    private List<IItem> items = new List<IItem>();
    private IItem activeItem;
    private IUser user;

    private void Awake() {
        user = GetComponent<IUser>();
    }

    private void OnEnable() {
        if (user != null) {
            user.OnUse -= UseItem;
            user.OnUse += UseItem;
        }
    }
    
    private void OnDisable() {
        if (user != null) {
            user.OnUse -= UseItem;
        }
    }


    public void AddItem(IItem item) {
        items.Add(item);
        activeItem = item;
        Instantiate(activeItem.ItemSO.ItemPrefab, itemHolder.position, Quaternion.identity, itemHolder);
    }
    
    
    private void UseItem() {
        activeItem.Use();
    }
    

}
