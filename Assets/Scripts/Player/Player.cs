using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour, ITriggerCheckable
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Moveable moveable;
    public PlayerAttacker playerAttacker;

    public Transform finishPoint; //опрокинуть зависимость

    public event Action OnBattleBegan;
    public event Action OnBattleEnd;

    public bool IsChasing { get; set; }
    public bool IsBattle { get; set; }
    public List<BasicSkibidi> targetsInBattle;
    public BasicSkibidi currentTarget;

    private void Start()
    {
        moveable.Agent = agent;
        SetFinish();
    }

    private void OnEnable()
    {
        OnBattleBegan += playerAttacker.StartAttacking;
        OnBattleBegan += moveable.StopChasing;

        OnBattleEnd += playerAttacker.EndAttacking;
        OnBattleEnd += SetFinish;
    }

    private void Update()
    {
        if (IsChasing)
        {
            moveable.ChaseTarget(currentTarget.transform);
        }
    }

    private void SetFinish() => agent.SetDestination(finishPoint.position);


    #region Trigger Checks

    public void SetChasingStatus(bool isChasing, BasicSkibidi target)
    {
        IsChasing = isChasing;
        currentTarget = target;

    }

    public void SetBattleStatus(bool isBattle, BasicSkibidi target)
    {
        targetsInBattle.Add(target);
        IsBattle = isBattle;
        if (isBattle)
        {
            currentTarget = targetsInBattle[0];
            OnBattleBegan?.Invoke();
        }

    }

    public void AddEnemyToBattle(BasicSkibidi target)
    {
        targetsInBattle.Add(target);
    }

    #endregion
}
