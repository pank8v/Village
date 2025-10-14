using UnityEngine;

public class WeaponVisual : MonoBehaviour, IWeaponModule
{
   private IWeapon weapon;
   private Vector3 recoilOffset; private Quaternion recoilRotation;
   [SerializeField] private float recoilY = 2f;
   [SerializeField] private float recoilZ = 1f;
   [SerializeField] private float smoothTime = 2f;
   [SerializeField] private float returnSpeed = 10f;
   [SerializeField] private ParticleSystem muzzleFlash;

   public void Initialize(Weapon weapon) {
      this.weapon = weapon;
      if (this.weapon != null) {
         weapon.OnAttack += HandleShot;
      }
   }
   
   private void OnDisable() {
      if (weapon != null) {
         weapon.OnAttack -= HandleShot;
      }
   }
   

   private void Update() {
      recoilRotation = Quaternion.Slerp(recoilRotation, Quaternion.identity, Time.deltaTime * 10f);
      transform.localRotation = recoilRotation;
   }
   
   private void HandleShot() {
      HandleRecoil();
      muzzleFlash.Play();
   }

   private void HandleRecoil() {
      recoilRotation *= Quaternion.Euler(-20f, 0f, 0f);
   }
   

}
