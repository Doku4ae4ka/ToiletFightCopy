using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkibidiFactory
{
    void Load();
    void Create(EnemyType enemyType, Vector3 spawnPos);
}