using UnityEngine;
using UnityEngine.InputSystem;

public class Fly : MonoBehaviour
{
    [Header("Fly Stats")]
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float flyBackSpeed;
    [SerializeField] private float scaleFactor;
    [SerializeField] private int healthVal;
    
    public static int health;

    private Vector2 latMoveInput;
    private Vector2 longMoveInput;
    private Vector2 leftRightInput;

    private Vector3 startScale;

    private Rigidbody rb;

    private FlyMovement playerControls;

    private void Awake()
    {
        playerControls = new FlyMovement();
        startScale = transform.localScale;
        rb = GetComponent<Rigidbody>();
        health = healthVal;
    }

    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.y += latMoveInput.y * moveSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);
        position.x += leftRightInput.x * moveSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        if (Mathf.Abs(longMoveInput.y) > .01f)
        {
            position.z += longMoveInput.y * flyBackSpeed * Time.deltaTime;
        }
        else
        {
            if (Mathf.Abs(position.z) > 0.01f)
            {
                position.z = Mathf.Lerp(position.z, 0f, flyBackSpeed * Time.deltaTime);
            }
            else
            {
                position.z = 0f;
            }
        }
        position.z = Mathf.Clamp(position.z, minZ, maxZ);

        float scaleOffset = position.z * -scaleFactor;
        transform.localScale = new Vector3(
            startScale.x + scaleOffset,
            startScale.y + scaleOffset,
            startScale.z
        );

        rb.MovePosition(position);
    }

    public void LateralMove(InputAction.CallbackContext ctx)
    {
        latMoveInput = ctx.ReadValue<Vector2>();
    }
    public void LongMove(InputAction.CallbackContext ctx)
    {
        longMoveInput = ctx.ReadValue<Vector2>();
    }
    public void LeftRight(InputAction.CallbackContext ctx)
    {
        leftRightInput = ctx.ReadValue<Vector2>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
    }
}
