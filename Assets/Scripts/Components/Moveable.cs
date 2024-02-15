using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Moveable : MonoBehaviour
{
    public NavMeshAgent Agent { get; set; }
    private bool isChasing = false;
    private Transform _currentTarget;

    private void Update()
    {
        if (isChasing)
        {
            Agent.SetDestination(_currentTarget.position);
        }
    }

    public void ChaseTarget(Transform target)
    {
        _currentTarget = target;
        isChasing = true;
    }

    public void StopChasing()
    {
        Agent.isStopped = true;
        isChasing = false;
        Agent.transform.LookAt(_currentTarget);
    }

}
