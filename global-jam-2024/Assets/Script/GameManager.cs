using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] Dialog dialog;
    [SerializeField] int textCount;
    [SerializeField] bool isLaugh;

    private void Start()
    {
        GenerateDialog();
    }

    public void GenerateDialog()
    {
        dialog.line.Clear();

        int emojiCount = textCount / 2;

        if (isLaugh)
        {
            int laughEmoji = UnityEngine.Random.Range(0, emojiCount);
            int exceptLaughEmoji = emojiCount - laughEmoji;
            int text = textCount - emojiCount;

            if (laughEmoji >= emojiCount / 2)
            {
                for (int i = 0; i < laughEmoji; i++)
                {
                    TextType textType = new TextType();
                    textType.text = "<sprite=1>";
                    textType.isEmoji = true;
                    dialog.line.Add(textType);
                }

                for (int i = 0; i < exceptLaughEmoji; i++)
                {
                    TextType textType = new TextType();
                    textType.text = "<sprite=0>";
                    textType.isEmoji = true;
                    dialog.line.Add(textType);

                }
            }
            else
            {
                for (int i = 0; i < laughEmoji; i++)
                {
                    TextType textType = new TextType();
                    textType.text = "<sprite=0>";
                    textType.isEmoji = true;
                    dialog.line.Add(textType);
                }

                for (int i = 0; i < exceptLaughEmoji; i++)
                {
                    TextType textType = new TextType();
                    textType.text = "<sprite=1>";
                    textType.isEmoji = true;
                    dialog.line.Add(textType);

                }
            }


            for (int i = 0; i < text; i++)
            {
                TextType textType = new TextType();
                textType.text = "#@^%^@";
                textType.isEmoji = true;
                dialog.line.Add(textType);
            }

        }
        else
        {
            int laughEmoji = UnityEngine.Random.Range(0, emojiCount);
            int exceptLaughEmoji = emojiCount - laughEmoji;
            int text = textCount - emojiCount;

            if (laughEmoji >= emojiCount / 2)
            {
                for (int i = 0; i < laughEmoji; i++)
                {
                    TextType textType = new TextType();
                    textType.text = "<sprite=0>";
                    textType.isEmoji = true;
                    dialog.line.Add(textType);
                }

                for (int i = 0; i < exceptLaughEmoji; i++)
                {
                    TextType textType = new TextType();
                    textType.text = "<sprite=1>";
                    textType.isEmoji = true;
                    dialog.line.Add(textType);

                }
            }
            else
            {
                for (int i = 0; i < laughEmoji; i++)
                {
                    TextType textType = new TextType();
                    textType.text = "<sprite=1>";
                    textType.isEmoji = true;
                    dialog.line.Add(textType);
                }

                for (int i = 0; i < exceptLaughEmoji; i++)
                {
                    TextType textType = new TextType();
                    textType.text = "<sprite=0>";
                    textType.isEmoji = true;
                    dialog.line.Add(textType);

                }
            }


            for (int i = 0; i < text; i++)
            {
                TextType textType = new TextType();
                textType.text = "*#&*#";
                textType.isEmoji = true;
                dialog.line.Add(textType);
            }
        }

        ShuffleSentence();

        dialog.ActiveDialog();
    }


    void ShuffleSentence()
    {
        int count = dialog.line.Count;
        int last = count - 1;
        for (int i = 0; i < dialog.line.Count; i++)
        {
            int index = UnityEngine.Random.Range(0, count);
            TextType currentText = dialog.line[i];
            dialog.line[i] = dialog.line[index];
            dialog.line[index] = currentText;
        }
    }

}
