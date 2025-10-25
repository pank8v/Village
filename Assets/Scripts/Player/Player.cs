using UnityEngine;
using System;

public class Player : MonoBehaviour, IInteractor,IUser, IInspector, IDamageable
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private Health health;
    [SerializeField] private InventoryComponent inventoryComponent;
    public event Action OnUse;
    public event Action<int> OnItemSwitch;
    public event Action OnInteract;
    public event Action OnAttack;
    public event Action OnDrop;
    public event Action OnReload;

    public string localLayerName = "LocalPlayer";
    public InventoryComponent InventoryComponent => inventoryComponent;
    [SerializeField] private Transform attackPosition;
    
    [SerializeField] private ObjectInspector objectInspector;
    public ObjectInspector ObjectInspector => objectInspector;

    public Transform AttackPosition => attackPosition;

    public void TryAddItem(IItem item) {
        InventoryComponent.AddItem(item);
    }
    
    private void OnEnable() {
        inputHandler.OnInteractTriggered += InteractTrigger;
        inputHandler.OnAttackTriggered += UseTrigger;
        inputHandler.OnDropTriggered += DropTrigger;
        inputHandler.OnItemSwitch += SwitchTrigger;
        inputHandler.OnReload += ReloadTrigger;
    }

    private void OnDisable() {
        inputHandler.OnInteractTriggered -= InteractTrigger;
        inputHandler.OnAttackTriggered -= UseTrigger;
        inputHandler.OnDropTriggered -= DropTrigger;
        inputHandler.OnItemSwitch -= SwitchTrigger;
        inputHandler.OnReload -= ReloadTrigger;
    }

    private void Start() {

        int layer = LayerMask.NameToLayer(localLayerName);
        SetLayerRecursively(gameObject, layer);
        
        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            mainCam.cullingMask &= ~(1 << layer);
        } 
    }
    
    
    void SetLayerRecursively(GameObject obj, int layer)
    {
        obj.layer = layer;
        foreach (Transform t in obj.transform)
            SetLayerRecursively(t.gameObject, layer);
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
    
    private void ReloadTrigger() {
        OnReload?.Invoke();
    }
    
    public void TakeDamage(float damage) {
        health.TakeDamage(damage);
    }

    public void InspectObject(GameObject item) {
        objectInspector.StartInspection(item);
    }
    
}
