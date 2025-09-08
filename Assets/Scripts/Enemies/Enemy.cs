using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minXSpawn;
    public float maxXSpawn;
    public float minYSpawn;
    public float maxYSpawn;
    public float ZSpawn;
    private void OnCollisionEnter(Collision collision)
    {
        // player layer
        if (collision.gameObject.layer == 6)
        {
            Fly.health--;
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }
}
