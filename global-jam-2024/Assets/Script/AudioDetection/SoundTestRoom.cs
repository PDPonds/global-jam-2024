using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class SoundTestRoom : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _soundPower;

    [SerializeField]
    private TextMeshProUGUI _laughThreshold;

    [SerializeField]
    private TextMeshProUGUI _micMode;

    float _maximumSoundPower;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentSoundPower = ((Mathf.Round(AudioLoudnessDetection.GetLoudnessFromMicrophone() * 100f)) / 100.0f);

        if (currentSoundPower >= _maximumSoundPower) 
        {
            _maximumSoundPower = currentSoundPower;
            _soundPower.text = _maximumSoundPower.ToString();
        }

        _laughThreshold.text =( (Mathf.Round(AudioLoudnessDetection.Threshold * 100f)) / 100.0f).ToString();

        _micMode.text = AudioLoudnessDetection.micMode.ToString();
    }

    public void GoToTutorialScene() 
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void ResetSoundPower() 
    {
        _maximumSoundPower = 0;
    }

    public void ResetThreshold()
    {
        AudioLoudnessDetection.Threshold =0.3f;
    }

    public void EditSoundThreshold(string newThreshold) 
    {
        bool result = float.TryParse(newThreshold, out float number);
        if (result)
        {
            AudioLoudnessDetection.Threshold = number;
        }
    }

    public void Back() 
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeToggleMode() 
    {
        if (AudioLoudnessDetection.micMode == MicMode.Always)
        {
            AudioLoudnessDetection.micMode = MicMode.Toggle;
            AudioLoudnessDetection.HandleMute();
        }
        else 
        {
            AudioLoudnessDetection.micMode = MicMode.Always;
        }
    }
}
