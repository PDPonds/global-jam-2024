using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : BaseState
{
    public override void EnterState(GameObject go)
    {
        SoundManager.Instance.ChageVolume("BGM2", 1f);

        PlayerMananger.instance.PlayWinningLight();
        if (AudioLoudnessDetection.micMode == MicMode.Toggle)
        {
            SoundManager.Instance.PlayOneShot("Cheer");
        }
        else 
        {
            SoundManager.Instance.PlayOneShot("SecretBGM");
            PlayerMananger.instance.OpenAllSecretBGs();
        }
        
    }

    public override void UpdateState(GameObject go)
    {
        if (GameManager.Instance.winUI.activeSelf || GameManager.Instance.secretWinUI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space) || AudioLoudnessDetection.IsMoreThanThreshold())
            {
                SoundManager.Instance.Stop("Cheer");
                SoundManager.Instance.Stop("SecretBGM");
                SoundManager.Instance.ChangePitch("BGM2", 1f);
                SoundManager.Instance.Stop("BGM2");
                SceneManager.LoadScene(0);
            }
        }
    }
}
