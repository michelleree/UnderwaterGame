using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //public GameObject[] foodPrefabs;
    //public GameObject[] trashPrefabs;
    public GameObject foodPrefab;
    public GameObject trashPrefab;  

    public float spawnInterval = 3f;
    public Vector3 spawnArea = new Vector3(10f, 1f, 10f);
    //public float spawnHeight = 8f;
    
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
        bool spawnFood = Random.value > 0.5f;
        /*GameObject prefab = spawnFood
            ? foodPrefabs[Random.Range(0, foodPrefabs.Length)]
            : trashPrefabs[Random.Range(0, trashPrefabs.Length)];*/
        
        GameObject prefab = spawnFood ? foodPrefab : trashPrefab;

        Vector3 pos = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            Random.Range(minHeight, maxHeight), //spawnHeight,
            Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        );

        Instantiate(prefab, pos, Quaternion.identity);
    }
}