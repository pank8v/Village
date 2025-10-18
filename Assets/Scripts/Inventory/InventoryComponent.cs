using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class InventoryComponent : MonoBehaviour
{
    [SerializeField] private int defaultLayerIndex = 0;
    [SerializeField] private int interactableLayerIndex = 3;
    [SerializeField] private Transform itemHolder;
    private List<IItem> items = new List<IItem>();
    private IItem activeItem;
    private IUser user;

    private void Awake() {
        user = GetComponent<IUser>();
    }

    private void OnEnable() {
        if (user != null) {
            user.OnUse += UseItem;
            user.OnDrop += DropItem;
        }
    }
    
    private void OnDisable() {
        if (user != null) {
            user.OnUse -= UseItem;
            user.OnDrop -= DropItem;

        }
    }
    


    public void AddItem(IItem item) {
        var itemGameObject = item.ItemGameObject;
        itemGameObject.transform.SetParent(itemHolder);
        itemGameObject.transform.localPosition = Vector3.zero;
        itemGameObject.layer = defaultLayerIndex;
        activeItem = itemGameObject.GetComponent<IItem>();
        var itemRb = itemGameObject.GetComponent<Rigidbody>();
        if (itemRb) {
            itemRb.isKinematic = true;
        }
    }


    private void DropItem() {
        if (activeItem != null) {
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
        else {
            Debug.Log("null");
        }
    }
    

}
