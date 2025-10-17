using UnityEngine;
using System;
public class Player : MonoBehaviour, IInteractor, IAttacker,IUser, IDamageable
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private Health health;
    [SerializeField] private InventoryComponent inventoryComponent;
    public event Action OnUse;
    public event Action OnInteract;
    public event Action OnAttack;

    public InventoryComponent InventoryComponent => inventoryComponent;
    [SerializeField] private Transform attackPosition;

    public Transform AttackPosition => attackPosition;
    
    
    private void OnEnable() {
        inputHandler.OnInteractTriggered += InteractTrigger;
    //    inputHandler.OnAttackTriggered += AttackTrigger;
    inputHandler.OnAttackTriggered += UseTrigger;
    
    }

    private void OnDisable() {
        inputHandler.OnInteractTriggered -= InteractTrigger;
        inputHandler.OnAttackTriggered -= UseTrigger;
      //  inputHandler.OnAttackTriggered -= AttackTrigger;
    }
    
    private void InteractTrigger() {
        OnInteract?.Invoke();
    }

    private void AttackTrigger() {
        OnAttack?.Invoke();
    }

    private void UseTrigger() {
        OnUse?.Invoke();
    }
    
    
    public void TakeDamage(float damage) {
        health.TakeDamage(damage);
    }
}
