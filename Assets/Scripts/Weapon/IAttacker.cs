using UnityEngine;
using System;

public interface IAttacker
{
    public event Action OnAttack;
    public Transform AttackPosition { get;  }
}
