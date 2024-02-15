using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform finishPoint;
    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private EnemyData[] enemyDatas; 
    [SerializeField] private EnemyMarker[] enemyMarkers;

    public override void InstallBindings()
    {
        BindSkibidiFactory();
        BindEnemyData();
        BindEnemyMarker();

        BindUnitHealth();
        BindDamageable();
        BindSkibidiAttacker();
        BindPlayerAttacker();

        BindPlayer();
        //понять что делать с матрешкой: UnitHealth -> Damageable -> SkibidiAttacker
    }

    private void BindPlayer()
    {
        Player player = Container.InstantiatePrefabForComponent<Player>(playerPrefab, startPoint.position, startPoint.rotation, null);
        player.finishPoint = finishPoint;

        Container
            .Bind<Player>()
            .FromInstance(player)
            .AsSingle();
    }

    private void BindUnitHealth()
    {
        Container
            .Bind<UnitHealth>()
            .To<UnitHealth>()
            .AsCached();
    }

    private void BindDamageable()
    {
        Container
            .Bind<Damageable>()
            .To<Damageable>()
            .AsCached();
    }

    private void BindSkibidiAttacker()
    {
        Container
            .Bind<SkibidiAttacker>()
            .To<SkibidiAttacker>()
            .AsCached();
    }

    private void BindPlayerAttacker()
    {
        Container
            .Bind<PlayerAttacker>()
            .To<PlayerAttacker>()
            .AsSingle();
    }

    private void BindSkibidiFactory()
    {
        Container
            .Bind<ISkibidiFactory>()
            .To<SkibidiFactory>()
            .AsSingle();
    }

    private void BindEnemyData()
    {
        Container
            .Bind<EnemyData[]>()
            .FromInstance(enemyDatas)
            .AsSingle();
    }

    private void BindEnemyMarker()
    {
        Container
            .Bind<EnemyMarker[]>()
            .FromInstance(enemyMarkers)
            .AsSingle();
    }

}
