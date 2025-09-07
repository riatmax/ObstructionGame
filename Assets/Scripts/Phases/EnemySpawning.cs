using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemySpawn", menuName = "Phases/EnemySpawn")]
public class EnemySpawning : ScriptableObject
{
    public GameObject enemyPrefab;
    public float spawnRate;
}
