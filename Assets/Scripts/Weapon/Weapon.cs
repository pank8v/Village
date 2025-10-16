using UnityEngine;
using System;

public class Weapon : MonoBehaviour, IWeapon
{
   public event Action OnAttack;
   public event Action OnReload;

   public float fireTimer = 0.5f;
   
   
   private IWeaponModule[] modules;
   public WeaponContext weaponContext;
   
   
   private void Awake() {
      modules = GetComponents<IWeaponModule>();
      for (int i = 0; i < modules.Length; i++) {
         modules[i].Initialize(this);
      }
   }

   private void Update() {
      fireTimer += Time.deltaTime;
   }
   
   public void Attack(Transform attackPos) {
      if (fireTimer >= weaponContext.fireRate) {
         weaponContext.attackPosition = attackPos;
         OnAttack?.Invoke();
         fireTimer = 0;
      }

   }
   
}
