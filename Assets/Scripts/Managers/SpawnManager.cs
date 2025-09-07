using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public void startSpawning(Phase p)
    {
        EnemySpawning[] enemies = p.enemySpawns;
        for (int i = 0; i < enemies.Length; i++)
        {
           // float randX = Random.Range(enemies[i].script.)
        }
    }
}
