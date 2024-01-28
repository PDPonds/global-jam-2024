using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
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

        SoundManager.Instance.Stop("TypeText");
    }

    public override void UpdateState(GameObject go) 
    { 
    
        if (GameManager.Instance.currentMood >= 80)
        {
            GameManager.Instance.fillLaughSpeed = 40;
        }

        currentPoint += Time.deltaTime * (GameManager.Instance.fillLaughSpeed  * 2);

        Image fill = GameManager.Instance.laughFill.GetComponent<Image>();
        fill.fillAmount = currentPoint / 100f;

        float startLaughPoint = midTargetPoint - (GameManager.Instance.laughPointSize / 2f);
        float endLaughPoint = midTargetPoint + (GameManager.Instance.laughPointSize / 2f);

        if (Input.GetKeyDown(KeyCode.Space) || AudioLoudnessDetection.IsMoreThanThreshold())
        {
            if (currentPoint >= startLaughPoint && currentPoint <= endLaughPoint)
            {
                if (GameManager.Instance.isLaugh)
                {
                    PlayerMananger.instance.PlayLaughSound(0.5f);
                    PlayerMananger.instance.HitButton();
                }
                else
                {
                    PlayerMananger.instance.NoHitButton();
                    SoundManager.Instance.PlayOneShot("Miss");
                }
            }
            else
            {
                PlayerMananger.instance.NoHitButton();
                SoundManager.Instance.PlayOneShot("Miss");
            }

            GameManager.Instance.SwitchState(GameManager.Instance.resultState);
        }

        if (currentPoint >= 100f)
        {
            if (GameManager.Instance.isLaugh)
            {
                PlayerMananger.instance.PlaySwallowSound(0.5f);
                PlayerMananger.instance.NoHitButton();
            }
            else
            {
                PlayerMananger.instance.BeSilent();
            }
        }

    }
}
