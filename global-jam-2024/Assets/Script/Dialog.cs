using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public textType[] line;
    public float speed;

    int index;

    void Start()
    {
        dialogText.text = string.Empty;
        index = 0;
        StartCoroutine(StartTypeDialog());

    }

    void Update()
    {
    }

    IEnumerator StartTypeDialog()
    {
        foreach (textType t in line)
        {
            if (t.isEmogi)
            {
                DrawEmogi();
                yield return new WaitForSeconds(speed);
            }
            else
            {
                yield return DrawFornt();
            }
        }
    }

    void DrawEmogi()
    {
        dialogText.text += line[index].text;
        index++;
    }

    IEnumerator DrawFornt()
    {
        foreach (char c in line[index].text)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(speed);
        }
        index++;

    }


}

[Serializable]
public class textType
{
    public string text;
    public bool isEmogi;
}