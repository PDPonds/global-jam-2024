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
        GameManager.Instance.debugText.gameObject.SetActive(false);
    }

    public override void UpdateState(GameObject go)
    {
        currentPoint += Time.deltaTime * (GameManager.Instance.fillLaughSpeed  * 2);

        Image fill = GameManager.Instance.laughFill.GetComponent<Image>();
        fill.fillAmount = currentPoint / 100f;

        float startLaughPoint = midTargetPoint - (GameManager.Instance.laughPointSize / 2f);
        float endLaughPoint = midTargetPoint + (GameManager.Instance.laughPointSize / 2f);
        
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            if (currentPoint >= startLaughPoint && currentPoint <= endLaughPoint)
            {
                if(GameManager.Instance.isLaugh)
                {
                    PlayerMananger.instance.HitButton();
                }
                else
                {
                    PlayerMananger.instance.NoHitButton();
                }
            }
            else
            {
                PlayerMananger.instance.NoHitButton();
            }

            GameManager.Instance.SwitchState(GameManager.Instance.resultState);
        }
        
        if(GameManager.Instance.isLaugh)
        {
            if (currentPoint >= 100f)
            {
                PlayerMananger.instance.NoHitButton();
            }

        }
        else
        {
            if (currentPoint >= 100f)
            {
                PlayerMananger.instance.HitButton();
            }
        }

    }
}
