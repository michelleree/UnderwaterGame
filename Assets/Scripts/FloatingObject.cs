using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float moveAmplitude = 0.2f;
    public float moveSpeed = 1f;

    public float rotationSpeed = 10f;

    private Vector3 startPos;
    private Vector3 randomOffset;
    private Vector3 randomRotationAxis;

    void Start()
    {
        startPos = transform.position;

        randomOffset = new Vector3(
            Random.Range(0f, 10f),
            Random.Range(0f, 10f),
            Random.Range(0f, 10f)
        );

        randomRotationAxis = Random.onUnitSphere;
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * moveSpeed + randomOffset.x) * moveAmplitude;
        float y = Mathf.Cos(Time.time * moveSpeed + randomOffset.y) * moveAmplitude;
        float z = Mathf.Sin(Time.time * moveSpeed + randomOffset.z) * moveAmplitude;

        transform.position = startPos + new Vector3(x, y, z);

        transform.Rotate(randomRotationAxis, rotationSpeed * Time.deltaTime);
    }
}