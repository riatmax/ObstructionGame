using UnityEngine;

[CreateAssetMenu(fileName = "NewPhase", menuName = "Phases/Phase")]
public class Phase : ScriptableObject
{
    public EnemySpawning[] enemySpawns;
    public float minProg;
    public float maxProg;
}
