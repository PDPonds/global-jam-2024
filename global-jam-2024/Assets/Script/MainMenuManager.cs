using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Button _exitButton;

    [SerializeField]
    private Button _soundTestButton;

    private bool hasStart;

    void Start()
    {
        AudioLoudnessDetection.InstantiateMicrophoneToAudioClip();
        _exitButton.onClick.AddListener(Exit);
        _soundTestButton.onClick.AddListener(GoToSoundTest);
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
        FadingUI.Instance.OnStopFading.AddListener(Application.Quit);
        FadingUI.Instance.StartFadeIn();
    }

    private void GoToSoundTest() 
    {
        FadingUI.Instance.OnStopFading.AddListener(LoadSoundTest);
        FadingUI.Instance.StartFadeIn();
    }

    private void LoadSoundTest()
    {
        SceneManager.LoadScene("SoundTestRoom");
    }

    private void GoToGameScene() 
    {
        SceneManager.LoadScene("SoundTestRoom");
    }

}
