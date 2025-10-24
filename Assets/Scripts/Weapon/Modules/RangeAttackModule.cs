using UnityEngine;

public class RangeAttackModule : MonoBehaviour, IWeaponModule
{
    [SerializeField] private Transform muzzleTransform;
    [SerializeField] private Bullet bullet;
    [SerializeField] private float maxRange = 200f;
    private Weapon weapon;

    
    
    public void Initialize(Weapon weapon) {
        this.weapon = weapon;
        if (this.weapon) {
            weapon.OnAttack -= Shoot;
            weapon.OnAttack += Shoot;
        }
    }

    private void Shoot() {
        Vector3 targetPoint;
        RaycastHit hit;
        Transform attackTransform = weapon.weaponContext.attackPosition;
        if (Physics.Raycast(attackTransform.position, attackTransform.forward, out hit, maxRange)) {
            targetPoint = hit.point;
        }
        else {
            targetPoint = attackTransform.position + attackTransform.forward * maxRange;

        }
        Vector3 direction = (targetPoint - muzzleTransform.position).normalized;
        
        bullet = Instantiate(bullet, muzzleTransform.position, muzzleTransform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb) {
            rb.AddForce(direction * 50f, ForceMode.Impulse);
        }
    }
}
