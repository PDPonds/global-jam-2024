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
        SupremeManager.instance.SetBoolAnim("isTalk", false);
        SoundManager.Instance.Stop("TypeText");

        GameManager.Instance.debugText.gameObject.SetActive(true);
        GameManager.Instance.debugText.text = $"<sprite=1> : {GameManager.Instance.dialog.duckCount} " +
            $"<sprite=0> : {GameManager.Instance.dialog.tankCount}";

        currentTime = 3;


    }

    public override void UpdateState(GameObject go)
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            if (GameManager.Instance.currentMood < 0)
            {
                GameManager.Instance.SwitchState(GameManager.Instance.loseState);
            }
            else if (GameManager.Instance.currentMood >= 100)
            {
                GameManager.Instance.SwitchState(GameManager.Instance.winState);
            }
            else
            {
                GameManager.Instance.SwitchState(GameManager.Instance.dialogState);
            }
        }
    }
}
