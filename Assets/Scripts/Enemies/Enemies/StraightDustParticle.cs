using UnityEngine;

public class StraightDustParticle : Enemy
{
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float moveSpeedMin;
    [SerializeField] private float moveSpeedMax;

    private float moveSpeed;

    private Rigidbody rb;

    private void Awake()
    {
        moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax);
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.x -= moveSpeed * Time.deltaTime;

        rb.MovePosition(position);
    }
}
