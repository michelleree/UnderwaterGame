using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform transformToFollow;
    [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -8);

    private Vector3 velocity = Vector3.zero;
    private PlayerInputActions inputActions;
    private InputAction moveAction;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Enable();
        moveAction = inputActions.Player.Move;
    }

    private void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        float moveX = input.x;
        float dynamicSmoothTime = Mathf.Lerp(smoothTime, smoothTime * 0.2f, Mathf.Abs(moveX));

        Vector3 flatForward = new Vector3(transformToFollow.forward.x, 0, transformToFollow.forward.z);
        Vector3 targetPosition = transformToFollow.position + Quaternion.LookRotation(flatForward) * offset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, dynamicSmoothTime);

        Vector3 lookDirection = transformToFollow.position - transform.position;
        lookDirection.y = 0;
        if (lookDirection.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}