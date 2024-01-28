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
    public GameObject playerlight;
    public GameObject silentlight;
    public GameObject winningLight;
    public GameObject []secretBGs;
    public GameObject laughFeedback;
    public GameObject silentFeedback;
    public GameObject spawnPoint;
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
        //SoundManager.Instance.Play("Laugh");
        yield return new WaitForSeconds(delay);

        foreach (var player in allPlayerObj)
        {
            SoundManager.Instance.Play(SoundManager.Instance.RandomSound(SoundManager.Instance.laughSoundList));
            //SoundManager.Instance.Play("Laugh");
        }
    }

    public void HitButton()
    {
        Instantiate(laughFeedback.gameObject, transform.position, transform.rotation, spawnPoint.transform);
        SoundManager.Instance.PlayOneShot("TapSuccess");
        playerlight.SetActive(true);
        GameManager.Instance.AddMood(20f);
        GameManager.Instance.dialog.RemoveSpeed();
        PlayAnimation("Laugh", 0.5f);
        GameManager.Instance.SwitchState(GameManager.Instance.resultState);

    }

    public void BeSilent()
    {
        Instantiate(silentFeedback.gameObject, transform.position, transform.rotation, spawnPoint.transform);
        SoundManager.Instance.PlayOneShot("Shh");
        silentlight.SetActive(true);
        GameManager.Instance.AddMood(20f);
        GameManager.Instance.dialog.RemoveSpeed();
        PlayAnimation("Laugh", 0.5f);
        GameManager.Instance.SwitchState(GameManager.Instance.resultState);

    }

    public void NoHitButton()
    {

        GameManager.Instance.RemoveMood(15f);
        GameManager.Instance.dialog.AddSpeed();
        PlayAnimation("Wrong", 0.5f);
        SupremeManager.instance.PlayAnimation("Piss");
        SupremeManager.instance.PlayRedLight();
        StartCoroutine(GameManager.Instance.camShake.Shake(0.2f, .1f));
        GameManager.Instance.SwitchState(GameManager.Instance.resultState);
        
    }

    public void PlayWinningLight() 
    {
        winningLight.SetActive(true);
    }

    public void OpenAllSecretBGs() 
    {
        foreach (GameObject bg in secretBGs) 
        {
            bg.SetActive(true);
        }
    }

    public void PlaySwallowSound(float delay)
    {
        StartCoroutine(PlaySwallowAndMissSoundIE(delay));
    }

    IEnumerator PlaySwallowAndMissSoundIE(float delay)
    {
        SoundManager.Instance.PlayOneShot("Swallow");
        yield return new WaitForSeconds(delay);
        SoundManager.Instance.PlayOneShot("Miss");

    }


}
