using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{
    public void Disable() 
    {
        gameObject.SetActive(false);
    }
}
