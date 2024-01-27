using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultState : BaseState
{
    float currentTime;
    public override void EnterState(GameObject go)
    {
        GameManager.Instance.dialogObj.SetActive(false);
        GameManager.Instance.laughtBar.SetActive(false);
        currentTime = 3;
    }

    public override void UpdateState(GameObject go)
    {
        //Play Animation
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            GameManager.Instance.SwitchState(GameManager.Instance.dialogState);

        }
    }
}
