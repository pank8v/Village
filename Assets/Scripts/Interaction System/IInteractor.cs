using UnityEngine;
using System;

public interface IInteractor
{
   public event Action OnInteract;
   public bool CheckRequiredItem(string itemId);
}
