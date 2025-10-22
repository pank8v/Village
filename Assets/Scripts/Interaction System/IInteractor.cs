using UnityEngine;
using System;

public interface IInteractor
{
   public ObjectInspector ObjectInspector { get; }
   public event Action OnInteract;
}
