using System;
using UnityEngine;
public interface IUser
{
    public Transform AttackPosition { get;  }

    public InventoryComponent InventoryComponent { get; }
    public ObjectInspector ObjectInspector { get; }
    public event Action OnUse;
    public event Action OnDrop;
    public event Action<int> OnItemSwitch;
    public event Action OnReload;
}
