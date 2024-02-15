using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Damageable
{
    private UnitHealth _unitHealth;

    [Inject]
    private void Construct(UnitHealth unitHealth)
    {
        _unitHealth = unitHealth;
    }

    public event Action<int> OnDamageApplied;

    public void ApplyDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _unitHealth.Health -= ProcessDamage(damage);
        OnDamageApplied?.Invoke(damage);
    }

    public virtual int ProcessDamage(int damage) => damage;
}
