using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : BaseState
{
    public override void EnterState(GameObject go)
    {
        SoundManager.Instance.ChageVolume("BGM", 1f);
    }

    public override void UpdateState(GameObject go)
    {
        if (GameManager.Instance.winUI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space) || AudioLoudnessDetection.IsMoreThanThreshold())
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
