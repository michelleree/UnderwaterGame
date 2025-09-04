using UnityEngine;
using UnityEngine.UIElements;

public class GameUIController : MonoBehaviour
{
    public FoodCollector player;

    private Label foodLabel;
    private Label healthLabel;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        foodLabel = root.Q<Label>("FoodLabel");
        healthLabel = root.Q<Label>("HealthLabel");
    }

    void Update()
    {
        foodLabel.text = "Food: " + player.foodCount;
        healthLabel.text = "Health: " + player.health;
    }
}
