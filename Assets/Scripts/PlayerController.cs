using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    private Rigidbody rb;
    private PlayerInputActions inputActions;

    private InputAction moveAction;
    private InputAction ascendAction;
    private InputAction descendAction;
    
    [SerializeField] private Transform model;
    [SerializeField] private float maxLeanAngle = 15f;
    [SerializeField] private float leanSpeed = 5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        inputActions = new PlayerInputActions();
        inputActions.Enable();

        moveAction = inputActions.Player.Move;
        ascendAction = inputActions.Player.Ascend;
        descendAction = inputActions.Player.Descend;
    }

    void FixedUpdate()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        float moveZ = input.y;
        float moveX = input.x;

        float turn = moveX * rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turn, 0f));

        float moveY = 0f;
        if (ascendAction.IsPressed())
        {
            moveY = 1f;
        }

        if (descendAction.IsPressed())
        {
            moveY = -1f;
        }

        Vector3 inputDir = new Vector3(moveX, 0f, moveZ);
        Vector3 worldDir = transform.rotation * inputDir;

        if (moveY != 0f)
        {
            worldDir += Vector3.up * moveY;
        }

        if (worldDir.sqrMagnitude > 1f)
        {
            worldDir.Normalize();
        }
        rb.MovePosition(rb.position + worldDir * moveSpeed * Time.fixedDeltaTime);

        float targetZ = moveX * maxLeanAngle;
        Vector3 euler = model.localEulerAngles;
        if (euler.z > 180f)
        {
            euler.z -= 360f;
        }
        euler.z = Mathf.Lerp(euler.z, targetZ, Time.fixedDeltaTime * leanSpeed);
        model.localEulerAngles = euler;
    }
    
    public void DisableControls()
    {
        inputActions.Disable();
    }
}