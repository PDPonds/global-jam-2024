using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogState : BaseState
{
    public override void EnterState(GameObject go)
    {
        GameManager.Instance.dialogObj.SetActive(true);
        GameManager.Instance.GenerateDialog();
    }

    public override void UpdateState(GameObject go)
    {
        Dialog dialog = GameManager.Instance.dialog;
        if(dialog.CheckAllTextInDialog())
        {
            GameManager.Instance.SwitchState(GameManager.Instance.laughState);
        }
    }
}
