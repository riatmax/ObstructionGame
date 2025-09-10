using UnityEngine;

public class Ear : MonoBehaviour
{
    public static bool inPos;
    [SerializeField] private GameObject earPoint;

    private void Awake()
    {
        inPos = false;
    }

    private void Update()
    {
        if (GameManager.gameProgress >= 95)
        {
            Vector3 pos = transform.position;
            Vector3 ear = earPoint.transform.position;
            if (!((Mathf.Abs(pos.x - ear.x) <= .01f) && (Mathf.Abs(pos.y - ear.y) <= .01f)))
            {
                pos.x -= Time.deltaTime;
                transform.position = pos;
            }
            else
            {
                inPos = true;
            }
        }
    }
}
