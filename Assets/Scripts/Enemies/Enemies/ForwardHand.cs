using UnityEngine;

public class ForwardHand : Enemy
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float scaleFactor;

    private Rigidbody rb;

    private BoxCollider bc;

    private bool moving;

    private Vector3 startScale;

    private float age;

    private void Awake()
    {
        moving = false;
        startScale = transform.localScale;
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        bc.enabled = false;
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;

        if (moving)
        {
            bc.enabled = true;
            pos.z += moveSpeed * Time.deltaTime;
            rb.MovePosition(pos);
            
        }
        float scaleOffset = age * scaleFactor;
        transform.localScale = new Vector3(
            startScale.x + scaleOffset,
            startScale.y + scaleOffset,
            startScale.z
        );
    }

    private void Update()
    {
        age += Time.deltaTime;
    }

    public void startMovingFunc()
    {
        rb.MovePosition(new Vector3(transform.position.x, transform.position.y, -1f));
        moving = true;
    }
}
