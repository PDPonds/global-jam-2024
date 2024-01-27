using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : BaseState
{
    public override void EnterState(GameObject go)
    {
        GameManager.Instance.winUI.SetActive(false);

    }

    public override void UpdateState(GameObject go)
    {
        if (GameManager.Instance.winUI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
