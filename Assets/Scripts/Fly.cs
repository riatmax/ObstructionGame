using UnityEngine;
using UnityEngine.InputSystem;

public class Fly : MonoBehaviour
{
    [Header("Fly Stats")]
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    [SerializeField] private float maxZ;
    [SerializeField] private float minZ;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float flyBackSpeed;
    [SerializeField] private float scaleFactor;

    private Vector2 latMoveInput;
    private Vector2 longMoveInput;

    private Vector3 startScale;

    private FlyMovement playerControls;

    private void Awake()
    {
        playerControls = new FlyMovement();
        startScale = transform.localScale;
    }

    private void Update()
    {
        Vector3 position = transform.position;
        position.y += latMoveInput.y * moveSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);
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

        float scaleOffset = position.z * scaleFactor;
        transform.localScale = new Vector3(
            startScale.x + scaleOffset,
            startScale.y + scaleOffset,
            startScale.z
        );

        transform.position = position;
    }

    public void LateralMove(InputAction.CallbackContext ctx)
    {
        latMoveInput = ctx.ReadValue<Vector2>();
    }
    public void LongMove(InputAction.CallbackContext ctx)
    {
        longMoveInput = ctx.ReadValue<Vector2>();
    }
}
