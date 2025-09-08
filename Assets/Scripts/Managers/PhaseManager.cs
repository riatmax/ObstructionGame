using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    public Phase[] phases;
    public List<Phase> currPhasesList;
    //private List<EnemySpawning> enemySpawnList;
    private float gameProg;
    private SpawnManager sm;
    private int phaseIndex = 0;
    private Dictionary<Phase, Coroutine> activePhaseCoroutines = new();

    private void Awake()
    {
        sm = FindFirstObjectByType<SpawnManager>();
        SortPhases();
        //LoadEnemySpawns(phases);
        currPhasesList = new List<Phase>();
    }
    private void Update()
    {
        gameProg = GameManager.gameProgress;

        if (phaseIndex < phases.Length && phases[phaseIndex] != null)
        { 
            if (gameProg > phases[phaseIndex].minProg && !currPhasesList.Contains(phases[phaseIndex]))
            {
                Phase newPhase = phases[phaseIndex];
                currPhasesList.Add(newPhase);
                StartPhase(newPhase);
                //sm.startSpawning(phases[phaseIndex]);
                phaseIndex++;
            }
        }

        for (int i = currPhasesList.Count - 1; i >= 0; i--)
        {
            if (gameProg > currPhasesList[i].maxProg)
            {
                StopPhase(currPhasesList[i]);
                currPhasesList.RemoveAt(i);
                //stop spawn logic
            }
        }
    }

    private void StartPhase(Phase p)
    {
        Coroutine c = StartCoroutine(sm.Spawning(p));
        activePhaseCoroutines[p] = c;
    }
    private void StopPhase(Phase p)
    {
        if (activePhaseCoroutines.TryGetValue(p, out Coroutine c))
        {
            StopCoroutine(c);
            activePhaseCoroutines.Remove(p);
        }
    }
    public void SortPhases()
    {
        for (int i = 0; i < phases.Length; i++)
        {
            for (int j = 0; j < phases.Length - i - 1; j++)
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
    public void StopPhases()
    {
        foreach (var kvp in activePhaseCoroutines)
        {
            if (kvp.Value != null)
                StopCoroutine(kvp.Value);
        }
        activePhaseCoroutines.Clear();
        currPhasesList.Clear();
        phaseIndex = 0;
    }
   /* public void LoadEnemySpawns(Phase[] ps)
    {
        for (int i = 0; i < ps.Length; i++)
        {
            for (int j = 0; j < ps[i].enemySpawns.Length; j++)
            {
                enemySpawnList.Add(ps[i].enemySpawns[j]);
            }
        }
    }*/
    
}
