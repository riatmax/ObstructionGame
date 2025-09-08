using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float gameProgress;
    public float gp;

    [SerializeField] private float progressSpeedModifier;

    private void Start()
    {
        gameProgress = 0;
    }
    private void Update()
    {
        gp = gameProgress;
        gameProgress += progressSpeedModifier * Time.deltaTime;
        gameProgress = Mathf.Clamp(gameProgress, 0, 100);
    }
}
