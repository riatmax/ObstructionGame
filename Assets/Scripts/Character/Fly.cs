using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

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

    [SerializeField] private GameObject flyPoint;

    [SerializeField] private TMP_Text winText;
    [SerializeField] private GameObject button;
    
    public static int health;

    private Vector2 latMoveInput;
    private Vector2 longMoveInput;
    private Vector2 leftRightInput;

    private Vector3 startScale;

    private Rigidbody rb;
    private BoxCollider bc;

    private FlyMovement playerControls;
    private PlayerInput pi;

    private void Awake()
    {
        pi = FindFirstObjectByType<PlayerInput>();
        startScale = transform.localScale;
        rb = GetComponent<Rigidbody>();
        health = healthVal;
        bc = GetComponent<BoxCollider>();
        winText.enabled = false;
        button.SetActive(false);
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
        if (GameManager.gameProgress >= 95)
        {
            bc.enabled = false;
            StartCoroutine(startEndSeq());
        }
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

    private IEnumerator startEndSeq()
    {
        pi.enabled = false;
        Vector3 targetPos = new Vector3(-6f, flyPoint.transform.position.y, 0f);
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, .00005f);
            yield return null; // wait for next frame
        }
        yield return new WaitUntil(() => Ear.inPos);
        targetPos = flyPoint.transform.position;
        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, .00005f);
            yield return null;
        }
        yield return new WaitUntil(() => (Vector3.Distance(transform.position, targetPos) > 0.01f));
        Time.timeScale = 0f;
        winText.enabled = true;
        button.SetActive(true);
        Destroy(gameObject);
    }
}
