using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameProgress;

    [SerializeField] private float progressSpeedModifier;

    private void Start()
    {
        gameProgress = 0;
    }
    private void Update()
    {
        gameProgress += progressSpeedModifier * Time.deltaTime;
        gameProgress = Mathf.Clamp(gameProgress, 0, 100);
    }
}
