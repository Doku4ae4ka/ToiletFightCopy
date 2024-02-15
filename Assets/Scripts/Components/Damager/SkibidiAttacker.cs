using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SkibidiAttacker : MonoBehaviour, IDamager
{
    public int Damage { get; set; }
    public float CritChance { get; set; }
    public float AttackInterval { get; set; }

    private Damageable _damageable;

    private bool attackAvailable;
    private bool attackInProcess;

    [Inject]
    private void Construct(Damageable damageable)
    {
        _damageable = damageable;
    }

    public void Update()
    {
        if (attackAvailable && !attackInProcess)
        {
            PerformAttack();
        }
    }

    public void StartAttacking()
    {
        attackAvailable = true;
    }

    public void EndAttacking()
    {
        attackAvailable = false;
    }

    public void PerformAttack()
    {
        if (attackAvailable && !attackInProcess)
        {
            var multiplier = TryGetCrit();
            var damage = Damage * multiplier;
            //Damageable.ApplyDamage(damage);
            Debug.Log("Skibidi Attacked!");
            StartCoroutine(PerformAttackInterval());
        }

    }

    private int TryGetCrit()
    {
        float randValue = Random.value;
        return randValue > CritChance ? 2 : 1;
    }

    private IEnumerator PerformAttackInterval()
    {
        attackInProcess = true;
        yield return new WaitForSeconds(2f);
        attackInProcess = false;
    }
}
