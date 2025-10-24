using UnityEngine;

public class InventorySlot
{
    public IItem Item;
    public bool IsLocked;
    public string SlotType;
    public int Count = 1;
    public bool IsEmpty => Item == null;
}
