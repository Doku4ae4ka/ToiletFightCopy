using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cinemachine;
using UnityEngine.Playables;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera1;
    [SerializeField] private CinemachineVirtualCamera virtualCamera2;
    [SerializeField] private CinemachineTargetGroup targetGroup;

    private Player _player;
    private CinemachineTargetGroup.Target _target;

    [Inject]
    private void Construct(Player player)
    {
        _player = player;
    }

    private void OnEnable()
    {
        _player.OnBattleBegan += StartFilmingBattle;
        _player.OnBattleEnd += StopFilmingBattle;
    }

    private void Start()
    {
        virtualCamera1.Follow = _player.transform;
        virtualCamera1.LookAt = _player.transform;

        AddNewTarget(_player.transform, 0);
    }

    private void StartFilmingBattle()
    {
        virtualCamera2.Priority += 2;

        AddNewTarget(_player.currentTarget.transform, 1);
    }

    private void StopFilmingBattle()
    {
        virtualCamera2.Priority -= 2;
    }

    private void AddNewTarget(Transform target, int number)
    {
        _target.target = target;
        _target.weight = 1;
        targetGroup.m_Targets.SetValue(_target, number);
    }

}
