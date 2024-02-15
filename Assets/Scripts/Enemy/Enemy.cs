using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public abstract class Enemy : MonoBehaviour
{

    protected Player _player;

    [Inject]
    private void Construct(Player player)
    {
        _player = player;
    }

}
