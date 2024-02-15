using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PlayerAttacker : MonoBehaviour, IDamager
{
    public int Damage { get; set; }
    public float CritChance { get; set; }
    public float AttackInterval{ get; set; }

    private Damageable _damageable;

    private bool attackAvailable;
    private bool attackInProcces;
    private bool blockInProcces;

    [Inject]
    private void Construct(Damageable damageable)
    {
        _damageable = damageable;
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
        if (attackAvailable && !attackInProcces && !blockInProcces)
        {
            var multiplier = TryGetCrit();
            var damage = Damage * multiplier;
            //Damageable.ApplyDamage(damage);
            Debug.Log("Player Attacked!");
            StartCoroutine(PerformAttackInterval());
        }

    }

    public void StartBlock(BaseEventData data)
    {
        if(attackAvailable && !blockInProcces)
        {
            Debug.Log("Player Started Blocking!");
            blockInProcces = true;
        }
    }

    public void EndBlock(BaseEventData data)
    {
        if (attackAvailable)
        {
            Debug.Log("Player Stopped Blocking!");
            blockInProcces = false;
        }
    }

    private int TryGetCrit()
    {
        float randValue = Random.value;
        return randValue > CritChance ? 2 : 1;
    }

    private IEnumerator PerformAttackInterval()
    {
        attackInProcces = true;
        yield return new WaitForSeconds(2f);
        attackInProcces = false;
    }
}
