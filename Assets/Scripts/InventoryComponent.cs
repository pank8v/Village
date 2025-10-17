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
            user.OnUse += UseItem;
        }
    }
    
    private void OnDisable() {
        if (user != null) {
            user.OnUse -= UseItem;
        }
    }


    public void AddItem(GameObject item) {
        var newItem = Instantiate(item, itemHolder.position, Quaternion.identity, itemHolder);
        activeItem = newItem.GetComponent<IItem>();
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
