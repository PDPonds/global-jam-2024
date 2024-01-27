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
        GameManager.Instance.debugText.gameObject.SetActive(false);
        SoundManager.Instance.Play("TypeText");

    }

    public override void UpdateState(GameObject go)
    {
        Dialog dialog = GameManager.Instance.dialog;
        if(dialog.CheckAllTextInDialog())
        {
            GameManager.Instance.SwitchState(GameManager.Instance.laughState);
        }

        if (Input.GetKeyDown(KeyCode.Space) || AudioLoudnessDetection.IsMoreThanThreshold())
        {
            GameManager.Instance.RemoveMood(10f);
            GameManager.Instance.dialog.AddSpeed();
            PlayerMananger.instance.PlayAnimation("Wrong", 0.5f);
            SupremeManager.instance.PlayAnimation("Piss");
            SupremeManager.instance.PlayRedLight();
            SoundManager.Instance.PlayOneShot("Swallow");
            SoundManager.Instance.PlayOneShot("Miss");

            GameManager.Instance.SwitchState(GameManager.Instance.resultState);
        }

    }
}
