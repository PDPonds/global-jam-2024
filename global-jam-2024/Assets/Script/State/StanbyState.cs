using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StanbyState : BaseState
{
    float currentTime;
    public override void EnterState(GameObject go)
    {
        currentTime = 3f;
        GameManager.Instance.dialogObj.SetActive(false);
        GameManager.Instance.laughtBar.SetActive(false);
        GameManager.Instance.loseUI.SetActive(false);
        GameManager.Instance.winUI.SetActive(false);
        GameManager.Instance.debugText.gameObject.SetActive(false);

        SupremeManager.instance.SetBoolAnim("isTalk", false);

    }

    public override void UpdateState(GameObject go)
    {
        currentTime -= Time.deltaTime;
        if(currentTime < 0)
        {
            GameManager.Instance.SwitchState(GameManager.Instance.dialogState);
        }
    }
}
