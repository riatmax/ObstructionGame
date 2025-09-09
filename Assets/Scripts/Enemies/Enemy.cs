using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minXSpawn;
    public float maxXSpawn;
    public float minYSpawn;
    public float maxYSpawn;
    public float ZSpawn;

    private void Awake()
    {
        GameManager.activeEnemies.Add(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        // player layer
        if (other.gameObject.layer == 6)
        {
            GameManager.activeEnemies.Remove(gameObject);
            Fly.health--;
            Destroy(gameObject);
        }
        if (other.gameObject.layer == 7)
        {
            GameManager.activeEnemies.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
