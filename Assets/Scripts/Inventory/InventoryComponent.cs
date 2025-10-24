using UnityEngine;
using System.Collections.Generic;

using Unity.Mathematics;
using UnityEditor;

public class InventoryComponent : MonoBehaviour
{
    [SerializeField] private int defaultLayerIndex = 0;
    [SerializeField] private int interactableLayerIndex = 3;
    [SerializeField] private int maxItems = 6;
    [SerializeField] private Transform itemHolder;
    
    private Inventory _inventory;
    private IUser _user;

    private void Awake() {
        _inventory = new Inventory(maxItems);
        _user = GetComponent<IUser>();
    }

    private void OnEnable() {
        if (_user != null) {
            _user.OnUse += UseItem;
            _user.OnDrop += DropActive;
            _user.OnItemSwitch += SwitchItem;
            _user.OnReload += Reload;

            _inventory.OnItemAdded += HandleItemAdded;
            _inventory.OnItemRemoved += HandleItemRemoved;
            _inventory.OnItemSwitched += HandleItemSwitched;
        }
    }
    
    private void OnDisable() {
        if (_user != null) {
            _user.OnUse -= UseItem;
            _user.OnDrop -= DropActive;
            _user.OnItemSwitch -= SwitchItem;
            _user.OnReload -= Reload;
        }
    }

    private void HandleItemAdded(InventorySlot slot) {
        var itemGO = slot.Item.ItemGameObject;
        itemGO.transform.SetParent(itemHolder);
        itemGO.transform.localPosition = Vector3.zero;
        itemGO.transform.localRotation = Quaternion.identity;
        itemGO.layer = 0;
        if (itemGO.TryGetComponent(out Rigidbody rb)) {
            rb.isKinematic = true;
        }

        if (_inventory.ActiveSlot != slot) {
            itemGO.SetActive(false);
        }
        else {
            itemGO.SetActive(true);
        }
    }

    private void HandleItemRemoved(IItem item) {
        var itemGO = item.ItemGameObject;
        itemGO.transform.SetParent(null);
        itemGO.layer = 3;
        if (itemGO.TryGetComponent(out Rigidbody rb))
            rb.isKinematic = false;
    }

    private void HandleItemSwitched(InventorySlot slot) {
        for (int i = 0; i < maxItems; i++) {
            var it = _inventory.GetSlot(i).Item;
            if (it?.ItemGameObject != null) {
                it.ItemGameObject.SetActive(it == slot.Item);
            }

        }
    }
    
    private void SwitchItem(int index) {
        _inventory.SwitchItem(index);
    }

    
    public void AddItem(IItem item) {
        _inventory.AddItem(item);
    }
    
    private void DropActive() {
      _inventory.DropActive();
    }
    
    private void UseItem() {
        var item = _inventory.ActiveSlot.Item;
        item?.Use(_user.AttackPosition);
    }

    private void Reload() {
        var weapon = _inventory.ActiveSlot.Item as IWeapon;
        if (weapon != null) {
            weapon.Reload();
        }
    }

}
