using System;
using UnityEngine;

public interface IWeapon
{
    public event Action OnAttack;
    public event Action OnReload;
    public void Attack(Transform attackPos);
}
