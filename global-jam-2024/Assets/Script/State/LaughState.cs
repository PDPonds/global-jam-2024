using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaughState : BaseState
{
    float currentPoint = 0;

    int midTargetPoint = 75;

    public override void EnterState(GameObject go)
    {
        SupremeManager.instance.SetBoolAnim("isTalk", false);
        GameManager.Instance.laughtBar.SetActive(true);
        currentPoint = 0;
    }

    public override void UpdateState(GameObject go)
    {
        currentPoint += Time.deltaTime * (GameManager.Instance.fillLaughSpeed  * 2);

        Image fill = GameManager.Instance.laughFill.GetComponent<Image>();
        fill.fillAmount = currentPoint / 100f;

        float startLaughPoint = midTargetPoint - (GameManager.Instance.laughPointSize / 2f);
        float endLaughPoint = midTargetPoint + (GameManager.Instance.laughPointSize / 2f);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentPoint >= startLaughPoint && currentPoint <= endLaughPoint)
            {
                if(GameManager.Instance.isLaugh)
                {
                    GameManager.Instance.AddMood(15f);
                    GameManager.Instance.dialog.RemoveSpeed();
                    PlayerMananger.instance.PlayAnimation("Laugh", 0.5f);
                    
                }
                else
                {
                    GameManager.Instance.RemoveMood(10f);
                    GameManager.Instance.dialog.AddSpeed();
                    PlayerMananger.instance.PlayAnimation("Wrong", 0.5f);
                    SupremeManager.instance.PlayAnimation("Piss");
                }
            }
            else
            {
                GameManager.Instance.RemoveMood(10f);
                GameManager.Instance.dialog.AddSpeed();
                PlayerMananger.instance.PlayAnimation("Wrong", 0.5f);
                SupremeManager.instance.PlayAnimation("Piss");

            }

            GameManager.Instance.SwitchState(GameManager.Instance.resultState);

        }
        
        if(GameManager.Instance.isLaugh)
        {
            if (currentPoint >= 100f)
            {
                GameManager.Instance.RemoveMood(10f);
                GameManager.Instance.dialog.AddSpeed();
                PlayerMananger.instance.PlayAnimation("Wrong", 0.5f);
                SupremeManager.instance.PlayAnimation("Piss");

                GameManager.Instance.SwitchState(GameManager.Instance.resultState);
            }

        }
        else
        {
            if (currentPoint >= 100f)
            {
                GameManager.Instance.SwitchState(GameManager.Instance.resultState);
            }
        }

    }
}
