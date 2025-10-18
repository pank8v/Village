using System;
using UnityEngine;
public interface IUser
{
    public Transform AttackPosition { get;  }

    public InventoryComponent InventoryComponent { get; }
    public event Action OnUse;
    public event Action OnDrop;
}
