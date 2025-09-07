using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemySpawn", menuName = "Phases/EnemySpawn")]
public class EnemySpawning : ScriptableObject
{
    public GameObject enemyPrefab;
    public int num;
    public float spawnRate;
    public Enemy script;
}
