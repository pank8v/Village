using UnityEngine;

[System.Serializable]   
public class WeaponContext
{
    public bool canAttack = true;
    public int reloadTime = 2;
    public int initialAmmo = 10;
    public int ammo = 10;
    public Transform attackPosition;
    public float fireRate = 0.5f;

}
