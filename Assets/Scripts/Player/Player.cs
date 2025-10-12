using UnityEngine;
using System;
public class Player : MonoBehaviour, IInteractor, IAttacker
{
    [SerializeField] private InputHandler inputHandler;
    public event Action OnInteract;
    public event Action OnAttack;

    [SerializeField] private Transform attackPosition;

    public Transform AttackPosition {
        get => attackPosition;
    }
    

    private void OnEnable() {
        inputHandler.OnInteractTriggered += InteractTrigger;
        inputHandler.OnAttackTriggered += AttackTrigger;
    }

    private void OnDisable() {
        inputHandler.OnInteractTriggered -= InteractTrigger;
        inputHandler.OnAttackTriggered -= AttackTrigger;
    }
    
    private void InteractTrigger() {
        OnInteract?.Invoke();
    }

    private void AttackTrigger() {
        OnAttack?.Invoke();
    }
    
}
