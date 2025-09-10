using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static float gameProgress;
    public float gp;
    [SerializeField] private TMP_Text ui;

    public static List<GameObject> activeEnemies = new List<GameObject>();

    private PhaseManager pm;

    [SerializeField] private float progressSpeedModifier;

    private int health;
    private bool initHealth = false;

    private void Awake()
    {
        gameProgress = 0;
        pm = FindFirstObjectByType<PhaseManager>();
        health = Fly.health;
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
        if (!initHealth)
        {
            health = Fly.health;
            initHealth = true;
        }
        ui.text = $"Health: {Fly.health}/{health}";
    }
}
