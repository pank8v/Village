using UnityEngine;
using System;
using Mirror;

public class Weapon : MonoBehaviour, IWeapon, IItem
{
   public event Action OnAttack;
   public event Action OnReload;

   public float fireTimer = 0.5f;
   
   private IWeaponModule[] modules;
   public WeaponContext weaponContext;

   private GameObject itemGameObject;
   public GameObject ItemGameObject => itemGameObject;
   
   private void Awake() {
      itemGameObject = gameObject;
      modules = GetComponents<IWeaponModule>();
      for (int i = 0; i < modules.Length; i++) {
         modules[i].Initialize(this);
      }
   }
   
   private void Update() {
      fireTimer += Time.deltaTime;
   }

   public void Use(Transform raycastPosition) {
      Attack(raycastPosition);
   }

   public void Reload() {
      OnReload?.Invoke();
   }
   
   public void Attack(Transform attackPos) {
      if (fireTimer >= weaponContext.fireRate && weaponContext.ammo > 0 && weaponContext.canAttack) {
         weaponContext.attackPosition = attackPos;
         OnAttack?.Invoke();
         weaponContext.ammo--;
         fireTimer = 0;
      }

   }
   
   
}
