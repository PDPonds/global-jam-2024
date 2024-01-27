using UnityEngine;

public static class AudioLoudnessDetection
{
    public static float Threshold = 0.2f;

    private const int _sampleWindow = 64;

    private static AudioClip _microphoneClip;

    public static bool isMute;

    public static void InstantiateMicrophoneToAudioClip() 
    {
        string microphoneName = Microphone.devices[0];
        _microphoneClip = Microphone.Start(microphoneName, true, 100, AudioSettings.outputSampleRate);
    }

    public static float GetLoudnessFromMicrophone() 
    {
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

    public static void SetMute(bool mute) 
    {
        isMute = mute;
    }
}
