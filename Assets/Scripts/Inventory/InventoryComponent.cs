using UnityEngine;
using System.Collections.Generic;
using Mirror;
using Unity.Mathematics;
using UnityEditor;

public class InventoryComponent : NetworkBehaviour
{
    [SerializeField] private int defaultLayerIndex = 0;
    [SerializeField] private int interactableLayerIndex = 3;
    [SerializeField] private int maxItems = 6;
    [SerializeField] private Transform itemHolder;
    private IItem[] items;
    private IItem activeItem;
    private int activeItemIndex;
    private IUser user;

    private void Awake() {
        items = new IItem[maxItems];
        user = GetComponent<IUser>();
    }

    private void OnEnable() {
        if (user != null) {
            user.OnUse += UseItem;
            user.OnDrop += DropItem;
            user.OnItemSwitch += SwitchItem;
        }
    }
    
    private void OnDisable() {
        if (user != null) {
            user.OnUse -= UseItem;
            user.OnDrop -= DropItem;
            user.OnItemSwitch -= SwitchItem;
        }
    }
     
    private void SwitchItem(int index) {
        if (index < 0 || index >= items.Length) return;
        if (activeItemIndex == index) return;
        
        if (activeItem != null && activeItem.ItemGameObject != null)
            activeItem.ItemGameObject.SetActive(false);
        
        activeItem = items[index];
        activeItemIndex = index;
        
        if (activeItem != null && activeItem.ItemGameObject != null)
            activeItem.ItemGameObject.SetActive(true);

    }

    

     
    public void AddItem(IItem item) {
        int slotIndex = -1;
        for (int i = 0; i < items.Length; i++) {
            if (items[i] == null) {
                slotIndex = i;
                break;
            }
        }
        if (slotIndex == -1) {
            return;
        }
        
        items[slotIndex] = item;
        
        var itemGO = item.ItemGameObject;
        itemGO.transform.SetParent(itemHolder);
        itemGO.transform.localPosition = Vector3.zero;
        itemGO.layer = 0;

        var itemRb = itemGO.GetComponent<Rigidbody>();
        if (itemRb) itemRb.isKinematic = true;
        
        if (activeItem == null) {
            activeItem = item;
            activeItemIndex = slotIndex;
            itemGO.SetActive(true); 
        } else {
            itemGO.SetActive(false); 
        }
        
        if (activeItem == null) {
            SwitchItem(slotIndex);
        }
        
    }
    
    
    private void DropItem() {
       if (activeItem != null) {
            items[activeItemIndex] = null;
           var itemGameObject = activeItem.ItemGameObject;
           itemGameObject.transform.SetParent(null);
           itemGameObject.layer = interactableLayerIndex;
           activeItem = null;
          
           var itemRb = itemGameObject.GetComponent<Rigidbody>();
           if (itemRb) {
               itemRb.isKinematic = false;
           }
        }
    }
    
    private void UseItem() {
        if (activeItem != null) {
            activeItem.Use(user.AttackPosition);

        }
    }
    

}
