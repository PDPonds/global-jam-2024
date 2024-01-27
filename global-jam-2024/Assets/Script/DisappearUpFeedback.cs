using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearUpFeedback : MonoBehaviour
{
    [SerializeField]
    float countDownTime = 2.0f;

    [SerializeField]
    float speed = 2.0f;

    float currentCountDown;

    private void Start()
    {
        currentCountDown = countDownTime;
    }

    void Update()
    {
        currentCountDown -= Time.deltaTime;

        if (currentCountDown < 0) 
        {
            Destroy(this.gameObject);
        }

        transform.position += new Vector3(0, Time.deltaTime * 2.0f, 0);
    }
}
