using UnityEngine;
using UnityEngine.InputSystem;

public class Fly : MonoBehaviour
{
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    [SerializeField] private float moveSpeed;

    private Vector2 movementInput;

    private FlyMovement playerControls;

    private void Awake()
    {
        playerControls = new FlyMovement();
    }

    private void Update()
    {
        Vector2 position = transform.position;
        position.y += movementInput.y * moveSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;
    }

    public void LateralMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }
}
