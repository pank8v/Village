using Unity.Mathematics;
using UnityEngine;

public class WeaponComponent : MonoBehaviour
{
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private GameObject weaponPrefab;
    private IWeapon currentWeapon;
    
    private IAttacker attacker;
    
    
    private void Awake() {
        attacker = GetComponent<IAttacker>();
    }

    private void OnEnable() {
        if (attacker != null) {
            attacker.OnAttack += UseWeapon;
        }
    }

    private void Start() {
        Instantiate(weaponPrefab, weaponHolder.position, quaternion.identity, weaponHolder);
        currentWeapon = GetComponentInChildren<IWeapon>();
    }

    private void OnDisable() {
        if (attacker != null) {
            attacker.OnAttack -= UseWeapon;
        }
    }
    
    private void UseWeapon() {
        if (currentWeapon != null) {
            currentWeapon.Attack(attacker.AttackPosition);
        }
    }
}
