using UnityEngine;
using System;
public class Player : MonoBehaviour, IInteractor, IAttacker,IUser, IDamageable
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private Health health;
    [SerializeField] private InventoryComponent inventoryComponent;
    public event Action OnUse;
    public event Action<int> OnItemSwitch;
    public event Action OnInteract;
    public event Action OnAttack;
    public event Action OnDrop;

    public InventoryComponent InventoryComponent => inventoryComponent;
    [SerializeField] private Transform attackPosition;

    public Transform AttackPosition => attackPosition;
    
    
    private void OnEnable() {
        inputHandler.OnInteractTriggered += InteractTrigger;
    //    inputHandler.OnAttackTriggered += AttackTrigger;
    inputHandler.OnAttackTriggered += UseTrigger;
    inputHandler.OnDropTriggered += DropTrigger;
    inputHandler.OnItemSwitch += SwitchTrigger;
    
    }

    private void OnDisable() {
        inputHandler.OnInteractTriggered -= InteractTrigger;
        inputHandler.OnAttackTriggered -= UseTrigger;
        inputHandler.OnDropTriggered -= DropTrigger;
        inputHandler.OnItemSwitch -= SwitchTrigger;

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

    private void DropTrigger() {
        OnDrop?.Invoke();
    }

    private void SwitchTrigger(int index) {
        OnItemSwitch?.Invoke(index);
    }
    
    public void TakeDamage(float damage) {
        health.TakeDamage(damage);
    }
}
