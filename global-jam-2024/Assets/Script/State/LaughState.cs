using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaughState : BaseState
{
    float startPoint = 0;
    float targetPoint = 100f;
    public override void EnterState(GameObject go)
    {
        GameManager.Instance.laughtBar.SetActive(true);
    }

    public override void UpdateState(GameObject go)
    {
        startPoint += Time.deltaTime * GameManager.Instance.fillLaughSpeed;

        Slider slider = GameManager.Instance.laughtBar.GetComponent<Slider>();
        slider.value = startPoint;
        slider.maxValue = targetPoint;

    }
}
