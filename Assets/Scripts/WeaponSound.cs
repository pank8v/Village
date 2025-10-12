using UnityEngine;
using FMODUnity;

public class WeaponSound : MonoBehaviour
{
   [SerializeField] private EventReference shootEvent;
   private IWeapon weapon;
   private void Awake() {
      weapon = GetComponent<IWeapon>();
   }

   private void OnEnable() {
      weapon.OnAttack += PlayShootSound;
   }

   private void OnDisable() {
      weapon.OnAttack -= PlayShootSound;
   }
   
   private void PlayShootSound() {
      RuntimeManager.PlayOneShot(shootEvent, transform.position);
   }
   
}
