using UnityEngine;
using UnityEngine.UIElements;

public class GameOverUI : MonoBehaviour
{
    private UIDocument uiDocument;
    private VisualElement root;
    private Button playAgainButton;
    private Button mainMenuButton;
    private Button quitButton;

    private MainMenuUI mainMenuUI;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;

        playAgainButton = root.Q<Button>("PlayAgainButton");
        mainMenuButton = root.Q<Button>("MainMenuButton");
        quitButton = root.Q<Button>("QuitButton");

        playAgainButton.clicked += OnPlayAgainClicked;
        mainMenuButton.clicked += OnMainMenuClicked;
        quitButton.clicked += OnQuitClicked;

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

        Time.timeScale = 1f;
    }

    private void OnMainMenuClicked()
    {
        root.style.display = DisplayStyle.None;

        if (mainMenuUI != null)
            mainMenuUI.ShowMainMenu();
    }

    private void OnQuitClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}