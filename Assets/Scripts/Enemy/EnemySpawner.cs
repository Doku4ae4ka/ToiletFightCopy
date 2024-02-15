using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    private ISkibidiFactory _skibidiFactory;
    private EnemyMarker[] _enemyMarkers;
    private Player _player;

    private int currentGroup = 0;

    [Inject]
    private void Construct(ISkibidiFactory skibidiFactory, EnemyMarker[] enemyMarkers, Player player)
    {
        _skibidiFactory = skibidiFactory;
        _enemyMarkers = enemyMarkers;
        _player = player;
    }

    private void OnEnable()
    {
        _player.OnBattleEnd += SpawnEnemiesInGroup;
    }

    private void Awake()
    {
        _skibidiFactory.Load();
        SpawnEnemiesInGroup();
    }

    public void SpawnEnemiesInGroup()
    {
        foreach(EnemyMarker marker in _enemyMarkers)
        {
            if (currentGroup == marker.Group)
                _skibidiFactory.Create(marker.EnemyType, marker.transform.position);
        }
        currentGroup++;
    }
}
