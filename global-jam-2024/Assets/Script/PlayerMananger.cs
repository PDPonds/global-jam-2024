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

}
