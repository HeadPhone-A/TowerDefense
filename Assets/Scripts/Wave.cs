using UnityEngine;

[System.Serializable]
public class Wave
{
    public EnemyLists[] enemyLists;
}

[System.Serializable]
public class EnemyLists
{
    public GameObject enemyPrefab;
    public int spawnCount;
    public float spawnRate;
}
