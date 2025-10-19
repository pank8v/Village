using UnityEngine;
using FMODUnity;

public class WeaponSound : MonoBehaviour, IWeaponModule
{
   [SerializeField] private EventReference shootEvent;
   private IWeapon weapon;

   public void Initialize(Weapon weapon) {
      this.weapon = weapon;
      if (this.weapon != null) {
         weapon.OnAttack += PlayShootSound;
      }
   }
   
   private void OnDestroy() {
      if (weapon != null) {
         weapon.OnAttack -= PlayShootSound;
      }
   }
   
   private void PlayShootSound() {
      RuntimeManager.PlayOneShot(shootEvent, transform.position);
   }
   
}
