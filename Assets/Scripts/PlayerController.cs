using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;        // Bewegungsgeschwindigkeit
    public float rotationSpeed = 100f;  // Drehgeschwindigkeit

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Input abfragen
        float moveZ = 0f;
        float moveX = 0f;
        float moveY = 0f;

        if (Keyboard.current.wKey.isPressed) moveZ = 1f;
        if (Keyboard.current.sKey.isPressed) moveZ = -1f;
        if (Keyboard.current.aKey.isPressed) moveX = -1f;
        if (Keyboard.current.dKey.isPressed) moveX = 1f;
        if (Keyboard.current.eKey.isPressed) moveY = 1f;
        if (Keyboard.current.qKey.isPressed) moveY = -1f;

        // Rotation links/rechts
        float turn = moveX * rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turn, 0f));

        // Direkte Bewegung (vorwärts/rückwärts + hoch/runter)
        Vector3 movement = transform.forward * moveZ + Vector3.up * moveY;
        movement.Normalize(); // damit Diagonalbewegung nicht schneller wird
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
