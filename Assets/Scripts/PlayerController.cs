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

        float moveY = 0f;
        if (ascendAction.IsPressed()) moveY = 1f;
        if (descendAction.IsPressed()) moveY = -1f;

        float turn = moveX * rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turn, 0f));

        Vector3 movement = transform.forward * moveZ + Vector3.up * moveY;
        if (movement.sqrMagnitude > 1f) movement.Normalize();

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}