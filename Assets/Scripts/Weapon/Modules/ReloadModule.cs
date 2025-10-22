using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadModule : MonoBehaviour, IWeaponModule
{
    private Weapon weapon;
    private bool isReloading;
    public void Initialize(Weapon weapon) {
        this.weapon = weapon;
        if (weapon != null) {
            weapon.OnReload -= Reload;
            weapon.OnReload += Reload;
        }
    }


    private void Reload() {
        if (weapon.weaponContext.ammo < weapon.weaponContext.initialAmmo && !isReloading) {
            StartCoroutine(ReloadRoutine());
        }
    }

    private IEnumerator ReloadRoutine() {
        isReloading = true;
        weapon.weaponContext.canAttack = false;
        yield return new WaitForSeconds(weapon.weaponContext.reloadTime);
        weapon.weaponContext.ammo = weapon.weaponContext.initialAmmo;
        isReloading = false;
        weapon.weaponContext.canAttack = true;
    }

    public void OnDestroy() {
        weapon.OnReload -= Reload;
    }
}
