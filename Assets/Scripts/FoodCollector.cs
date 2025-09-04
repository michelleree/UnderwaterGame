using UnityEngine;

public class FoodCollector : MonoBehaviour
{
    public int foodCount = 0;
    public int health = 5;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            foodCount++;
            Destroy(other.gameObject);
            Debug.Log("Food: " + foodCount);
        }
        else if (other.CompareTag("Trash"))
        {
            health--;
            Debug.Log("Health: " + health);
        }
    }
}
