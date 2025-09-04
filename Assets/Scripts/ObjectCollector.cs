using UnityEngine;
using UnityEngine.Events;

public class ObjectCollector : MonoBehaviour
{
    public int foodCount = 0;
    public int health = 5;
    
    public UnityEvent foodCollected;
    public UnityEvent trashCollected;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Food"))
        {
            foodCount++;
            Destroy(collider.gameObject);
            Debug.Log("Food: " + foodCount);
            foodCollected.Invoke();
        }
        else if (collider.CompareTag("Trash"))
        {
            health--;
            Destroy(collider.gameObject);
            Debug.Log("Health: " + health);
            trashCollected.Invoke();
        }
    }
}
