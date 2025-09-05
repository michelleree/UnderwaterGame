using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverUI : MonoBehaviour
{
    private UIDocument uiDocument;
    private VisualElement root;
    private Button playAgainButton;
    private Button mainMenuButton;
    private Button quitButton;

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
    }

    private void OnMainMenuClicked()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ShowGameOver()
    {
        root.style.display = DisplayStyle.Flex;

        var player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            player.DisableControls();
        }
    }

    private void OnPlayAgainClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnQuitClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}