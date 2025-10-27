using UnityEngine;
using DG.Tweening;
public class WeaponVisual : MonoBehaviour, IWeaponModule
{
   private IWeapon weapon;
   private Vector3 recoilOffset; private Quaternion recoilRotation;
   [SerializeField] private float recoilY = 2f;
   [SerializeField] private float recoilZ = 1f;
   [SerializeField] private float smoothTime = 2f;
   [SerializeField] private float returnSpeed = 10f;
   [SerializeField] private ParticleSystem muzzleFlash;

   private float reloadDuration = 2f; 
   [SerializeField] private float reloadRotationAngle = 360f; 
   
   
   public void Initialize(Weapon weapon) {
      this.weapon = weapon;
      if (this.weapon != null) {
         weapon.OnAttack += HandleShot;
         weapon.OnReload += HandleReload;
      }
   }
   
   private void OnDestroy() {
      if (weapon != null) {
         weapon.OnAttack -= HandleShot;
         weapon.OnAttack -= HandleReload;

      }
   }
   

   private void Update() {
      if (transform.parent != null) {
         recoilRotation = Quaternion.Slerp(recoilRotation, Quaternion.identity, Time.deltaTime * 10f);
         transform.localRotation = recoilRotation;
      }
   }
   
   private void HandleShot() {
      HandleRecoil();
      transform.DOShakePosition(0.1f, 0.02f, 10, 90, false, true);
      muzzleFlash.Play();
   }

   private void HandleReload() {
      transform.DOLocalRotate(new Vector3(0, 0, reloadRotationAngle), reloadDuration, RotateMode.FastBeyond360)
         .SetEase(Ease.InOutSine)
         .OnComplete(() => {
            transform.localRotation = Quaternion.identity; 
         });
   }

   private void HandleRecoil() {
      recoilRotation *= Quaternion.Euler(-20f, 0f, 0f);
   }
   

}
