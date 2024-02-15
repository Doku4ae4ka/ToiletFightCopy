using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamager
{
    public int Damage { get; set; }
    public float CritChance { get; set; }
    public float AttackInterval { get; set; }

    void StartAttacking();
    void EndAttacking();

    public void PerformAttack();
}
