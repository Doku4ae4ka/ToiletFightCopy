using UnityEngine;
using Zenject;

public class SkibidiFactory : ISkibidiFactory
{
    private const string BasicSkibidi = "Prefabs/BasicSkibidi";
    private readonly DiContainer _diContainer;

    private EnemyData[] _enemyDatas;

    public int currentLevel = 1;

    private Object _basicSkibidiPrefab;

    [Inject]
    private void Construct(EnemyData[] enemyDatas)
    {
        _enemyDatas = enemyDatas;
    }

    public SkibidiFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public void Load()
    {
        _basicSkibidiPrefab = Resources.Load(BasicSkibidi);
    }

    public void Create(EnemyType enemyType, Vector3 spawnPos)
    {
        switch(enemyType)
        {
            case EnemyType.BasicSkibidi:
                GameObject go = _diContainer.InstantiatePrefab(_basicSkibidiPrefab, spawnPos, Quaternion.identity, null);
                BasicSkibidi newSkibidi = go.GetComponent<BasicSkibidi>();
                FillWithSkibidiParameters(newSkibidi, enemyType);
                break;
        }
    }

    private void FillWithSkibidiParameters(BasicSkibidi newSkibidi, EnemyType enemyType)
    {
        var enemyData = GetEnemyData(enemyType.ToString());
        

    }

    public int CountEntities()
    {
        return 0;
    }

    public EnemyData GetEnemyData(string enemyType)
    {
        foreach (var data in _enemyDatas)
        {
            if (data.name == enemyType + "Data")
            {
                return data;
            }
        }
        Debug.LogError("Enemy data not found: " + enemyType);
        return null;
    }
}
