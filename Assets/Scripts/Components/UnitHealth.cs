using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth
{
    public int MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = value > 0 ? value : 0;
    }

    public int Health
    {
        get => _health;

        set
        {
            _health = Mathf.Clamp(value, 0, MaxHealth);
        }
    }

    private int _maxHealth;
    private int _health;

    public bool isAlive => Health > 0;
}
