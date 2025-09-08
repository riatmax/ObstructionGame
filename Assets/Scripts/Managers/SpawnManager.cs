using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public IEnumerator Spawning(Phase p)
    {
        while (true)
        {
            EnemySpawning[] enemies = p.enemySpawns;
            for (int i = 0; i < enemies.Length; i++)
            {
                float chance = enemies[i].spawnRate;
                if (Random.Range(0f, 100f) < chance)
                {
                    Vector3 spawnPos = new Vector3(
                        Random.Range(enemies[i].enemyPrefab.GetComponent<Enemy>().minXSpawn, enemies[i].enemyPrefab.GetComponent<Enemy>().maxXSpawn),
                        Random.Range(enemies[i].enemyPrefab.GetComponent<Enemy>().minYSpawn, enemies[i].enemyPrefab.GetComponent<Enemy>().maxYSpawn),
                        enemies[i].enemyPrefab.GetComponent<Enemy>().ZSpawn
                    );

                    Instantiate(enemies[i].enemyPrefab, spawnPos, Quaternion.identity);
                }
            }

            yield return null;
        }
    }
}
