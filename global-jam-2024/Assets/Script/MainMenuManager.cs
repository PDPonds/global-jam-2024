using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Button _playButton;

    [SerializeField]
    private Button _exitButton;

    void Start()
    {
        _playButton.onClick.AddListener(Play);
        _exitButton.onClick.AddListener(Exit);
    }

    private void Play()
    {
        FadingUI.Instance.OnStopFading.AddListener(GoToGameScene);
        FadingUI.Instance.StartFadeIn();
    }

    private void Exit()
    {
        FadingUI.Instance.StartFadeOut();
    }

    private void GoToGameScene() 
    {
        SceneManager.LoadScene("TutorialScene");
    }

}
