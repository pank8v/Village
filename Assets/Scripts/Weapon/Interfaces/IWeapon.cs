using System;
using UnityEngine;

public interface IWeapon
{
    public event Action OnAttack;
    public void Attack(Transform attackPos);
}
