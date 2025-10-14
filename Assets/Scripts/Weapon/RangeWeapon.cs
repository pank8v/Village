using UnityEngine;
using System;

public class RangeWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private Transform muzzleTransform;
    [SerializeField] private Bullet bullet;
    [SerializeField] private float maxRange = 200f;
    
    
    public event Action OnAttack;
    public event Action OnReload;

    
    public void Attack(Transform attackPos) {
        Vector3 targetPoint;
        RaycastHit hit;
        
        if (Physics.Raycast(attackPos.position, attackPos.forward, out hit, maxRange)) {
            targetPoint = hit.point;
        }
        else {
            targetPoint = attackPos.position + attackPos.forward * maxRange;

        }
        Vector3 direction = (targetPoint - muzzleTransform.position).normalized;
        
        bullet = Instantiate(bullet, muzzleTransform.position, muzzleTransform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb) {
            rb.AddForce(direction * 50f, ForceMode.Impulse);
        }
        OnAttack?.Invoke();
    }

    
    public void Reload() {
        
    }
    
}
