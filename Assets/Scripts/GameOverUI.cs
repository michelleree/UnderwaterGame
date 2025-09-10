using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverUI : MonoBehaviour
{
    private UIDocument uiDocument;
    private VisualElement root;
    private Button playAgainButton;
    private Button mainMenuButton;

    private MainMenuUI mainMenuUI;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;

        playAgainButton = root.Q<Button>("PlayAgainButton");
        mainMenuButton = root.Q<Button>("MainMenuButton");

        playAgainButton.clicked += OnPlayAgainClicked;
        mainMenuButton.clicked += OnMainMenuClicked;

        root.style.display = DisplayStyle.None;

        mainMenuUI = FindObjectOfType<MainMenuUI>();
    }

    public void ShowGameOver()
    {
        root.style.display = DisplayStyle.Flex;

        var player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            player.DisableControls();
        }

        Time.timeScale = 0f;
    }

    private void OnPlayAgainClicked()
    {
        root.style.display = DisplayStyle.None;

        var player = FindObjectOfType<PlayerController>();
        if (player != null)
            player.EnableControls();
        
        var gameUI = FindObjectOfType<GameUI>();
        if (gameUI != null)
            gameUI.ResetUIAndPlayer();

        Time.timeScale = 1f;
    }

    private void OnMainMenuClicked()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}