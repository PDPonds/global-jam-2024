using UnityEngine;


public enum MicMode
{
    Toggle,
    Always
}

public static class AudioLoudnessDetection
{
    public static float Threshold = 0.3f;

    private const int _sampleWindow = 64;

    private static AudioClip _microphoneClip;

    public static bool isDisable;

    public static bool isMute = true;

    public static MicMode micMode = MicMode.Toggle;

    public static void HandleMute() 
    {
        if (micMode == MicMode.Toggle)
        {
            if (Input.GetKey(KeyCode.T))
            {
                TurnOnMute();
            }
            else 
            {
                TurnOffMute();
            }
        }
        else 
        {
            isMute = false;
        }


    }

    public static void SetMute() 
    {
        isMute = !isMute;
    }

    public static void TurnOnMute()
    {
        isMute = false;
    }

    public static void TurnOffMute()
    {
        isMute = true;
    }

    public static void InstantiateMicrophoneToAudioClip() 
    {
        string microphoneName = Microphone.devices[0];
        _microphoneClip = Microphone.Start(microphoneName, true, 100, AudioSettings.outputSampleRate);
    }

    public static float GetLoudnessFromMicrophone() 
    {
        if (isMute) 
        {
            return 0;
        }

        if (_microphoneClip == null) 
        {
            InstantiateMicrophoneToAudioClip();
        }

        return  GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), _microphoneClip);
    }

    public static float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip) 
    {
        int startPosition = clipPosition - _sampleWindow;

        if (startPosition < 0) 
        {
            return 0;
        }

        float[] waveData = new float[_sampleWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0;

        for (int i = 0; i < _sampleWindow; i++) 
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        return totalLoudness / _sampleWindow;
    }

    public static bool IsMoreThanThreshold() 
    {
        return (GetLoudnessFromMicrophone() >= Threshold);
    }

    public static void SetMute(bool disable) 
    {
        isDisable = disable;
    }
}
