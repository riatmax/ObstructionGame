using UnityEngine;

public class Enemy : MonoBehaviour
{
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
