using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoundTestRoom : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _soundPower;

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
    }
}
