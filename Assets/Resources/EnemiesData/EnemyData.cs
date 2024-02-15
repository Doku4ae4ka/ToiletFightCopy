using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public GameObject EnemyPrefab;

    public int Health;

    public float speed;

    public int Damage;
    public float critChance;
}
