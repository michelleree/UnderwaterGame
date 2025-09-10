using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject trashPrefab;  
    public GameObject fishPrefab;  

    public float spawnInterval = 3f;
    public Vector3 spawnArea = new Vector3(10f, 1f, 10f);
    
    public float minHeight = 3f;
    public float maxHeight = 12f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        float rand = Random.value;

        GameObject prefab;

        if (rand < 0.45f)
        {
            prefab = foodPrefab;
        }
        else if (rand < 0.90f)
        {
            prefab = trashPrefab;
        }
        else
        {
            prefab = fishPrefab;
        }

        Vector3 pos = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            Random.Range(minHeight, maxHeight),
            Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        );

        Instantiate(prefab, pos, Quaternion.identity);
    }
}