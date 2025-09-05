using UnityEngine;

public class CrabController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotationSpeed = 5f;
    public float changeDirectionTime = 3f;

    private Vector3 moveDirection;
    private float timer;

    void Start()
    {
        ChooseNewDirection();
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ChooseNewDirection();
        }
    }

    void ChooseNewDirection()
    {
        float angle = Random.Range(0f, 360f);
        moveDirection = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)).normalized;
        timer = changeDirectionTime;
    }
}