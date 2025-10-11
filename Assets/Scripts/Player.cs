using UnityEngine;
using System;
public class Player : MonoBehaviour, IInteractor
{
    [SerializeField] private InputHandler inputHandler;
    public event Action OnInteract;


    private void OnEnable() {
        inputHandler.OnInteractTriggered += InteractTrigger;
    }

    private void OnDisable() {
        inputHandler.OnInteractTriggered -= InteractTrigger;
    }
    
    private void InteractTrigger() {
        OnInteract?.Invoke();
    }

}
