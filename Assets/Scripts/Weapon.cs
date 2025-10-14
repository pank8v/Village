using UnityEngine;
using System;

public class Weapon : MonoBehaviour, IWeapon
{
   public event Action OnAttack;
   public event Action OnReload;

   private IWeaponModule[] modules;
   public WeaponContext weaponContext;
   
   
   private void Awake() {
      modules = GetComponents<IWeaponModule>();
      for (int i = 0; i < modules.Length; i++) {
         modules[i].Initialize(this);
      }
   }
   
   public void Attack(Transform attackPos) {
      weaponContext.attackPosition = attackPos;
      OnAttack?.Invoke();
   }
   
}
