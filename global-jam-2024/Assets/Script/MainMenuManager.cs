using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Button _exitButton;

    private bool hasStart;

    void Start()
    {
        AudioLoudnessDetection.InstantiateMicrophoneToAudioClip();
        _exitButton.onClick.AddListener(Exit);
    }

    private void Update()
    {
        if (hasStart) 
        {
            return;
        }


        if (AudioLoudnessDetection.IsMoreThanThreshold() || Input.GetKeyDown("space")) 
        {
            Play();
        }
    }

    private void Play()
    {
        hasStart = true;
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
