using UnityEngine;
using System;

public class RangeWeapon : MonoBehaviour, IWeapon, IReloadable
{
    public event Action OnAttack;
    private Vector3 muzzlePosition;

    
    public void Attack(Transform attackPos) {
        Vector3 targetPoint;
        RaycastHit hit;
        if (Physics.Raycast(attackPos.position, attackPos.forward, out hit, 200f)) {
            targetPoint = hit.point;
            Debug.Log(hit.collider.gameObject.name);
        }
        else {
            targetPoint = Vector3.zero;
        }
        Vector3 direction = (targetPoint - muzzlePosition).normalized;
        
        OnAttack?.Invoke();

    }

    
    public void Reload() {
        
    }
    
}
