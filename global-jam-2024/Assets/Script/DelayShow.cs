using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayShow : MonoBehaviour
{
    [SerializeField]
    GameObject showObj;
    void Start()
    {
        StartCoroutine(DelayShowing());
    }

    IEnumerator DelayShowing() 
    {
        yield return new WaitForSeconds(1.0f);
        showObj.SetActive(true);
    }
}
