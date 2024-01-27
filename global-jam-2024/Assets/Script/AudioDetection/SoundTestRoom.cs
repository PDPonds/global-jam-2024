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
        float currentSoundPower = AudioLoudnessDetection.GetLoudnessFromMicrophone();

        if (currentSoundPower >= _maximumSoundPower) 
        {
            _maximumSoundPower = currentSoundPower;
            _soundPower.text = _maximumSoundPower.ToString();
        }

        _laughThreshold.text = AudioLoudnessDetection.Threshold.ToString();

        _micMode.text = AudioLoudnessDetection.micMode.ToString();

        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("TutorialScene");
        }
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
        if (AudioLoudnessDetection.micMode == MicMode.AlwaysTurnOn)
        {
            AudioLoudnessDetection.micMode = MicMode.Toggle;
        }
        else 
        {
            AudioLoudnessDetection.micMode = MicMode.AlwaysTurnOn;
        }
    }
}
