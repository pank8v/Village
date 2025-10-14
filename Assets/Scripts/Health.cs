using UnityEngine;
using System;


public class Health : MonoBehaviour
{
    [SerializeField] private ScriptableObject healthSO;
    [SerializeField] private string healthFieldName = "GetMaxHealth";

    private float maxHealth;
    private float health;
    public event Action OnHealthChanged;
    
    
    private void Start() {
       maxHealth = (float)healthSO.GetType().GetMethod(healthFieldName).Invoke(healthSO, null);
       health = maxHealth;
    }
    
    

    public void TakeDamage(float damage) {
        if (damage > 0) {
            health -= damage;
            OnHealthChanged?.Invoke();
            Debug.Log(health);
        }
    }

    public void AddHealth(float healthAmount) {
        if(health < maxHealth)
            health += healthAmount;
            OnHealthChanged?.Invoke();
    }
    
    
    
}
