using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private UIDocument uiDocument;
    private VisualElement root;
    private Button playButton;
    private Button setTimerButton;
    private Button quitButton;
    
    private SetTimerUI setTimerUI;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;

        playButton = root.Q<Button>("PlayButton");
        setTimerButton = root.Q<Button>("SetTimerButton");
        quitButton = root.Q<Button>("QuitButton");

        playButton.clicked += PlayButtonOnclicked;
        setTimerButton.clicked += SetTimerButtonOnclicked;
        quitButton.clicked += QuitButtonOnclicked;
        
        setTimerUI = FindObjectOfType<SetTimerUI>();
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void SetTimerButtonOnclicked()
    {
        HideMainMenu();

        if (setTimerUI != null)
        {
            setTimerUI.ShowTimerUI();
        }
    }

    private void PlayButtonOnclicked()
    {
        GameSettings.IsRunning = false;
        GameSettings.CurrentTime = 0f;
        GameSettings.FoodGoal = 0;

        SceneManager.LoadScene("GameScene");
    }

    private void QuitButtonOnclicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    
    public void HideMainMenu()
    {
        root.style.display = DisplayStyle.None;
    }
}