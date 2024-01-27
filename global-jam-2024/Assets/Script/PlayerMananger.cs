using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMananger : MonoBehaviour
{
    public static PlayerMananger instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject playerObj;
    public GameObject[] allPlayerObj;

    public void PlayAnimation(string name, float delay)
    {
        StartCoroutine(PlayAnimationIE(name, delay));
    }

    IEnumerator PlayAnimationIE(string name, float delay)
    {
        Animator playerAnim = playerObj.GetComponent<Animator>();
        playerAnim.Play(name);

        
        yield return new WaitForSeconds(delay);

        foreach (var player in allPlayerObj)
        {
            player.GetComponent<Animator>().Play(name);

            
        }
    }

    public void PlayLaughSound(float delay)
    {
        StartCoroutine(PlayLaughSoundIE(delay));
    }

    IEnumerator PlayLaughSoundIE(float delay)
    {
        SoundManager.Instance.Play(SoundManager.Instance.RandomSound(SoundManager.Instance.laughSoundList));

        yield return new WaitForSeconds(delay);

        foreach (var player in allPlayerObj)
        {
            SoundManager.Instance.Play(SoundManager.Instance.RandomSound(SoundManager.Instance.laughSoundList));

        }
    }

    public void HitButton()
    {
        SoundManager.Instance.PlayOneShot("TapSuccess");
        GameManager.Instance.AddMood(20f);
        GameManager.Instance.dialog.RemoveSpeed();
        PlayAnimation("Laugh", 0.5f);
        GameManager.Instance.SwitchState(GameManager.Instance.resultState);

    }

    public void NoHitButton()
    {
        SoundManager.Instance.PlayOneShot("Miss");
        GameManager.Instance.RemoveMood(15f);
        GameManager.Instance.dialog.AddSpeed();
        PlayAnimation("Wrong", 0.5f);
        SupremeManager.instance.PlayAnimation("Piss");
        StartCoroutine(GameManager.Instance.camShake.Shake(0.2f, .1f));
        GameManager.Instance.SwitchState(GameManager.Instance.resultState);
        
    }

}
