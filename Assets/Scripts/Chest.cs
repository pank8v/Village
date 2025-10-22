using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
   public void Interact(IInteractor interactor) {
      interactor.ObjectInspector.StartInspection(gameObject);
   }
}
