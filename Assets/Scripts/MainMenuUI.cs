using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    private UIDocument uiDocument;
    private VisualElement root;
    private Button playButton;
    private Button quitButton;

    private PlayerController player;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;

        playButton = root.Q<Button>("PlayButton");
        quitButton = root.Q<Button>("QuitButton");

        playButton.clicked += PlayButtonOnclicked;
        quitButton.clicked += QuitButtonOnclicked;

        root.style.display = DisplayStyle.None;

        player = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        root.style.display = DisplayStyle.Flex;
        
        if (player != null)
            player.DisableControls();

        Time.timeScale = 0f;
    }

    public void HideMainMenu()
    {
        root.style.display = DisplayStyle.None;
        
        if (player != null)
            player.EnableControls();

        Time.timeScale = 1f;
    }

    private void PlayButtonOnclicked()
    {
        HideMainMenu();
    }

    private void QuitButtonOnclicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
