using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    UIDocument uiDocument;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();

        VisualElement root = uiDocument.rootVisualElement;

        var playButton = root.Q<Button>("PlayButton");
        var quitButton = root.Q<Button>("QuitButton");
        
        playButton.clicked += PlayButtonOnclicked;
        quitButton.clicked += QuitButtonOnclicked;
    }

    private void QuitButtonOnclicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void PlayButtonOnclicked()
    {
        SceneManager.LoadScene("GameScene");
    }
}