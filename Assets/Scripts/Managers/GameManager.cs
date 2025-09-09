using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float gameProgress;
    public float gp;

    public static List<GameObject> activeEnemies = new List<GameObject>();

    private PhaseManager pm;

    [SerializeField] private float progressSpeedModifier;

    private void Awake()
    {
        gameProgress = 0;
        pm = FindFirstObjectByType<PhaseManager>();
    }
    private void Update()
    {
        gp = gameProgress;
        gameProgress += progressSpeedModifier * Time.deltaTime;
        gameProgress = Mathf.Clamp(gameProgress, 0, 100);

        if (gameProgress >= 100)
        {
            pm.StopAllCoroutines();
            while (GameManager.activeEnemies.Count > 0)
            {
                Destroy(GameManager.activeEnemies[0]);
                GameManager.activeEnemies.RemoveAt(0);
            }
        }
    }
}
