using UnityEngine;

public class StraightHand : Enemy
{
    [SerializeField] private float moveSpeed;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.x -= moveSpeed * Time.deltaTime;
        rb.MovePosition(pos);
    }
}
