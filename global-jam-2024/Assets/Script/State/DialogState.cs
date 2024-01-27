using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogState : BaseState
{
    public override void EnterState(GameObject go)
    {
        GameManager.Instance.dialogObj.SetActive(true);
        GameManager.Instance.GenerateDialog();
        SupremeManager.instance.SetBoolAnim("isTalk", true);

    }

    public override void UpdateState(GameObject go)
    {
        Dialog dialog = GameManager.Instance.dialog;
        if(dialog.CheckAllTextInDialog())
        {
            GameManager.Instance.SwitchState(GameManager.Instance.laughState);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.RemoveMood(10f);
            GameManager.Instance.dialog.AddSpeed();
            PlayerMananger.instance.PlayAnimation("PlayerWrong", 0.5f);
            SupremeManager.instance.PlayAnimation("Piss");

            GameManager.Instance.SwitchState(GameManager.Instance.resultState);
        }

    }
}
