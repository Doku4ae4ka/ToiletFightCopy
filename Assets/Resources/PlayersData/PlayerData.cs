using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public GameObject PlayerPrefab;

    public int Health;

    public float speed;

    public int Damage;
    public float critChance;
}

