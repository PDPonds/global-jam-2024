using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    #region Game State
    public BaseState currentState;

    public StanbyState stanbyState = new StanbyState();
    public DialogState dialogState = new DialogState();
    public LaughState laughState = new LaughState();
    public ResultState resultState = new ResultState();
    public LoseState loseState = new LoseState();
    public WinState winState = new WinState();
    #endregion

    [Header("===== Dialog =====")]
    public GameObject dialogObj;
    public Dialog dialog;
    [SerializeField] int textCount;
    public bool isLaugh;

    [Header("===== Laugh =====")]
    public GameObject laughtBar;
    public GameObject laughFill;
    public RectTransform laughPoint;
    public RectTransform laughBigPoint;

    [HideInInspector] public float fillLaughSpeed;

    public float laughPointSize;
    public float bigPointSize;

    [Header("===== Mood =====")]
    [SerializeField] Image fillMood;
    public float currentMood;

    [Header("===== Lose =====")]
    public GameObject loseUI;

    [Header("===== Win =====")]
    public GameObject winUI;

    [Header("===== Game ======")]
    public CameraShake camShake;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SwitchState(stanbyState);
        fillMood.fillAmount = currentMood / 100f;
    }

    private void Update()
    {
        currentState.UpdateState(transform.gameObject);
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(transform.gameObject);

        if (currentState == loseState)
        {
            StartCoroutine(lose());
        }
    }

    public void GenerateDialog()
    {
        dialog.line.Clear();

        int isLaughtCount = UnityEngine.Random.Range(0, 10);
        isLaugh = isLaughtCount > 3;

        int emojiCount = textCount / 2;

        if (isLaugh)
        {
            int dif = UnityEngine.Random.Range(0, 3);
            int laughEmoji = (emojiCount / 2) + dif;
            int exceptLaughEmoji = (emojiCount / 2) - dif;
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

                fillLaughSpeed = laughEmoji;
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

                fillLaughSpeed = exceptLaughEmoji;

            }


            for (int i = 0; i < text; i++)
            {
                TextType textType = new TextType();
                textType.text = "#";
                textType.isEmoji = true;
                dialog.line.Add(textType);
            }

        }
        else
        {
            int dif = UnityEngine.Random.Range(0, 3);
            int laughEmoji = (emojiCount / 2) + dif;
            int exceptLaughEmoji = (emojiCount / 2) - dif;
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
                fillLaughSpeed = laughEmoji;
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

                fillLaughSpeed = exceptLaughEmoji;

            }


            for (int i = 0; i < text; i++)
            {
                TextType textType = new TextType();
                textType.text = "*";
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

    public void AddMood(float amount)
    {
        currentMood += amount;
        fillMood.fillAmount = currentMood / 100f;
    }

    public void RemoveMood(float amount)
    {
        currentMood -= amount;
        fillMood.fillAmount = currentMood / 100f;
    }

    IEnumerator lose()
    {
        SupremeManager.instance.PlayAnimation("Slam");
        yield return new WaitForSeconds(.3f);
        StartCoroutine(camShake.Shake(0.2f, .1f));
        yield return new WaitForSeconds(1f);
        loseUI.SetActive(true);
    }

}
