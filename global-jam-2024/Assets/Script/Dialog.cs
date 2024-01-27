using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public List<TextType> line = new List<TextType>();

    public float startSpeed;
    public float speedMul;
    public float speed;

    int index;

    private void Awake()
    {
        speed = startSpeed;
    }

    public void AddSpeed()
    {
        speed += speedMul;
    }

    public void RemoveSpeed()
    {
        speed -= speedMul;
    }

    public void ActiveDialog()
    {
        dialogText.text = string.Empty;
        index = 0;
        StartCoroutine(StartTypeDialog());
    }

    IEnumerator StartTypeDialog()
    {
        foreach (TextType t in line)
        {
            if (t.isEmoji)
            {
                DrawEmoji();
                yield return new WaitForSeconds(speed);
            }
            else
            {
                yield return DrawFornt();
            }
        }
    }

    void DrawEmoji()
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

    public bool CheckAllTextInDialog()
    {
        string text = string.Empty;
        foreach (TextType t in line)
        {
            text += t.text;
        }

        return dialogText.text == text;
    }


}

[Serializable]
public class TextType
{
    public string text;
    public bool isEmoji;
}