using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    public Phase[] phases;
    private float gameProg;

    private void Update()
    {
        gameProg = GameManager.gameProgress;
    }
}
