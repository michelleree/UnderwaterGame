using UnityEngine;
using UnityEngine.Events;

public class ObjectCollector : MonoBehaviour
{
    public int foodCount = 0;
    public int health = 5;

    public UnityEvent foodCollected;
    public UnityEvent trashCollected;

    private GameOverUI gameOverUI;
    private GameWinUI gameWinUI;
    private SetTimerUI setTimerUI;
    private GameUI gameUI;

    private void Start()
    {
        gameOverUI = FindObjectOfType<GameOverUI>();
        gameWinUI = FindObjectOfType<GameWinUI>();
        setTimerUI = FindObjectOfType<SetTimerUI>();
        gameUI = FindObjectOfType<GameUI>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Food"))
        {
            foodCount++;
            Destroy(collider.transform.parent.gameObject);
            Debug.Log("Food: " + foodCount);
            foodCollected.Invoke();

            int currentGoal = (gameUI != null) ? gameUI.CurrentFoodGoal : 10;

            if (foodCount >= currentGoal)
            {
                Debug.Log("Food goal reached!");
                ShowWin();
            }
        }
        else if (collider.CompareTag("Trash"))
        {
            health--;
            Destroy(collider.transform.parent.gameObject);
            Debug.Log("Health: " + health);
            trashCollected.Invoke();

            if (health <= 0)
            {
                ShowGameOver();
            }
        }
    }

    private void ShowWin()
    {
        Debug.Log("You Win!");
        if (gameWinUI != null)
        {
            gameWinUI.ShowWinUI();
        }
    }

    private void ShowGameOver()
    {
        Debug.Log("Game Over");
        if (gameOverUI != null)
        {
            gameOverUI.ShowGameOver();
        }
    }
}