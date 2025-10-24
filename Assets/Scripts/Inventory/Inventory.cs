using UnityEngine;
using System;
public class Inventory
{
    public event Action<InventorySlot> OnItemAdded;
    public event Action<IItem> OnItemRemoved;
    public event Action<InventorySlot> OnItemSwitched;

    private readonly InventorySlot[] _slots;
    private int _activeIndex = -1;
    
    public InventorySlot ActiveSlot => _activeIndex >= 0  && _activeIndex < _slots.Length ? _slots[_activeIndex] : null;

    public Inventory(int maxSlots) {
        _slots = new InventorySlot[maxSlots];
        for (int i = 0; i < maxSlots; i++) {
            _slots[i] = new InventorySlot();
        }
    }

    public bool AddItem(IItem item) {
        for (int i = 0; i < _slots.Length; i++) {
            var slot = _slots[i];
            if (slot.IsEmpty) {
                slot.Item = item;
                OnItemAdded?.Invoke(slot);
                if (_activeIndex == -1) {
                    SwitchItem(i);
                }
                return true;
            }
        }  
        return false;
    }

    public void DropActive() {
        if (_activeIndex == -1) return;
        var slot = _slots[_activeIndex];
        if (slot.IsEmpty) return;
        var droppedItem = slot.Item;
        slot.Item = null;
        OnItemRemoved?.Invoke(droppedItem);
        for (int i = 0; i < _slots.Length; i++) {
            if (!_slots[i].IsEmpty) {
                SwitchItem(i);
                return;
            }
        }
        _activeIndex = -1;
    }
    
    
    public void SwitchItem(int index) {
        if (index < 0 || index >= _slots.Length) return;
        if(_slots[index].IsEmpty) return;
        if (_activeIndex == index) return;
        _activeIndex = index;
        OnItemSwitched?.Invoke(_slots[index]);
    }

    public InventorySlot GetSlot(int index) => _slots[index];
}
