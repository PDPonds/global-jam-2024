using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupremeManager : MonoBehaviour
{
    public static SupremeManager instance;

    public Transform mesh;
    public Animator anim;

    private void Awake()
    {
        instance = this;
    }

    public void PlayAnimation(string name)
    {
        anim.Play(name);
    }

    public void SetBoolAnim(string name, bool value)
    {
        anim.SetBool(name, value);
    }

}
