using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthSO", menuName = "Scriptable Objects/HealthSO")]
public class HealthSO : ScriptableObject
{
   [SerializeField] private float maxHealth;

   public float GetMaxHealth() {
      return maxHealth;
   }
}
