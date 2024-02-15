using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class BasicSkibidi : Enemy
{
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected Moveable _moveable;
    [SerializeField] protected SkibidiAttacker skibidiAttacker;

    public float Speed { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public int CritChance { get; set; }

    public void Start()
    {
        _moveable.Agent = agent;
        _moveable.ChaseTarget(_player.transform);
    }

    private void OnEnable()
    {
        _player.OnBattleBegan += skibidiAttacker.StartAttacking;
        _player.OnBattleBegan += _moveable.StopChasing;
    }

}
