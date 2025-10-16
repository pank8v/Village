using UnityEngine;
using System;

public interface IInteractor
{
   public InventoryComponent InventoryComponent { get; }
   public event Action OnInteract;
}
