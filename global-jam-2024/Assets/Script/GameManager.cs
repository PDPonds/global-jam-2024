using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    #region Game State
    public BaseState currentState;

    public StanbyState stanbyState = new StanbyState();
    public DialogState dialogState = new DialogState();
    public LaughState laughState = new LaughState();
    public ResultState resultState = new ResultState();
    #endregion

    [Header("===== Dialog =====")]
    public GameObject dialogObj;
    public Dialog dialog;
    [SerializeField] int textCount;
    bool isLaugh;

    [Header("===== Laugh =====")]
    public GameObject laughtBar;
    public float fillLaughSpeed;
    [SerializeField] float startLaughPoint;
    [SerializeField] float endLaughPoint;
    [SerializeField] float bigPointSize;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SwitchState(stanbyState);
    }

    private void Update()
    {
        currentState.UpdateState(transform.gameObject);
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(transform.gameObject);
    }

    public void GenerateDialog()
    {
        dialog.line.Clear();

        int isLaughtCount = UnityEngine.Random.Range(0, 10);
        isLaugh = isLaughtCount > 5;

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
