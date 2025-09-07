using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    public Phase[] phases;
    public List<Phase> currPhasesList;
    private List<EnemySpawning> enemySpawnList;
    private float gameProg;
    private SpawnManager sm;
    private int phaseIndex = 0;

    private void Awake()
    {
        sm = FindFirstObjectByType<SpawnManager>();
        SortPhases();
        LoadEnemySpawns(phases);
        currPhasesList = new List<Phase>();
    }
    private void Update()
    {
        gameProg = GameManager.gameProgress;

        if (phases[phaseIndex] != null)
        { 
            if (gameProg > phases[phaseIndex].minProg && !currPhasesList.Contains(phases[phaseIndex]))
            {
                currPhasesList.Add(phases[phaseIndex]);
                //start spawn logic
                phaseIndex++;
            }
        }

        for (int i = 0; i < currPhasesList.Count; i++)
        {
            if (gameProg > currPhasesList[i].maxProg)
            {
                currPhasesList.RemoveAt(i);
                //stop spawn logic
            }
        }
    }
    public void SortPhases()
    {
        for (int i = 0; i < phases.Length; i++)
        {
            for (int j = 0; j < phases.Length - i - 2; j++)
            {
                if (phases[j].minProg > phases[j + 1].minProg)
                {
                    Phase temp = phases[j];
                    phases[j] = phases[j + 1];
                    phases[j + 1] = temp;
                }
            }
        }
    }
    public void LoadEnemySpawns(Phase[] ps)
    {
        for (int i = 0; i < ps.Length; i++)
        {
            for (int j = 0; j < ps[i].enemySpawns.Length; j++)
            {
                enemySpawnList.Add(ps[i].enemySpawns[j]);
            }
        }
    }
    
}
