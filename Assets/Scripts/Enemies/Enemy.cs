using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float minXSpawn;
    [SerializeField] protected float maxXSpawn;
    [SerializeField] protected float minYSpawn;
    [SerializeField] protected float maxYSpawn;
    private void OnCollisionEnter(Collision collision)
    {
        // player layer
        if (collision.gameObject.layer == 6)
        {
            Fly.health--;
            Destroy(gameObject);
        }
    }
}
