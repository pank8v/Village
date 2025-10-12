using UnityEngine;

public class WeaponVisual : MonoBehaviour
{
   private IWeapon weapon;
   private Vector3 recoilOffset;
   private Vector3 initialPosition;
   private Quaternion recoilRotation;
   [SerializeField] private float recoilY = 2f;
   [SerializeField] private float recoilZ = 1f;
   [SerializeField] private float smoothTime = 2f;
   [SerializeField] private float returnSpeed = 10f;
   
   private void Awake() {
      weapon = GetComponent<IWeapon>();
   }

   private void OnEnable() {
      weapon.OnAttack += HandleRecoil;
   }
   
   private void OnDisable() {
      weapon.OnAttack -= HandleRecoil;
   }
   

   private void Start() {
      initialPosition = transform.localPosition;
   }

   private void Update() {
      recoilRotation = Quaternion.Slerp(recoilRotation, Quaternion.identity, Time.deltaTime * 10f);
      transform.localRotation = recoilRotation;
   }
   
   private void HandleRecoil() {
      recoilRotation *= Quaternion.Euler(-20f, 0f, 0f);
   }
   

}
