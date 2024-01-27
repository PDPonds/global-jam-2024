using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public GameObject cageObj;

    [Header("===== Win =====")]
    public GameObject winUI;
    public GameObject secretWinUI;

    [Header("===== Game ======")]
    public Transform camHolder;
    public CameraShake camShake;
    public TextMeshProUGUI debugText;
    public GameObject madel;

    private void Awake()
    {
        Instance = this;
        fillMood.fillAmount = 0;
    }

    private void Start()
    {
        SwitchState(stanbyState);

    }

    private void Update()
    {
        currentState.UpdateState(transform.gameObject);

        if (fillMood.fillAmount != currentMood / 100f)
        {
            fillMood.fillAmount = Mathf.Lerp(fillMood.fillAmount, currentMood / 100f, Time.deltaTime);
        }
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(transform.gameObject);

        if (currentState == loseState)
        {
            StartCoroutine(lose());
        }
        else if (currentState == winState)
        {
            StartCoroutine(win());
        }
    }

    public void GenerateDialog()
    {
        dialog.line.Clear();
        dialog.duckCount = 0;
        dialog.tankCount = 0;

        int isLaughtCount = UnityEngine.Random.Range(0, 10);
        isLaugh = isLaughtCount > 3;

        int emojiCount = textCount / 2;

        if (isLaugh)
        {
            int dif = UnityEngine.Random.Range(5, 10);
            int laughEmoji = (emojiCount / 2) + (dif / 2);
            int exceptLaughEmoji = (emojiCount / 2) - (dif / 2);
            int text = textCount - emojiCount;

            if (laughEmoji >= emojiCount / 2)
            {
                for (int i = 0; i < laughEmoji; i++)
                {
                    TextType textType = new TextType();
                    textType.text = "<sprite=1>";
                    textType.isEmoji = true;
                    dialog.line.Add(textType);
                    dialog.duckCount++;
                }

                for (int i = 0; i < exceptLaughEmoji; i++)
                {
                    TextType textType = new TextType();
                    textType.text = "<sprite=0>";
                    textType.isEmoji = true;
                    dialog.line.Add(textType);
                    dialog.tankCount++;

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
                    dialog.tankCount++;
                }

                for (int i = 0; i < exceptLaughEmoji; i++)
                {
                    TextType textType = new TextType();
                    textType.text = "<sprite=1>";
                    textType.isEmoji = true;
                    dialog.line.Add(textType);
                    dialog.duckCount++;

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
            int dif = UnityEngine.Random.Range(5, 10);
            int laughEmoji = (emojiCount / 2) + (dif / 2);
            int exceptLaughEmoji = (emojiCount / 2) - (dif / 2);
            int text = textCount - emojiCount;

            if (laughEmoji >= emojiCount / 2)
            {
                for (int i = 0; i < laughEmoji; i++)
                {
                    TextType textType = new TextType();
                    textType.text = "<sprite=0>";
                    textType.isEmoji = true;
                    dialog.line.Add(textType);
                    dialog.tankCount++;
                }

                for (int i = 0; i < exceptLaughEmoji; i++)
                {
                    TextType textType = new TextType();
                    textType.text = "<sprite=1>";
                    textType.isEmoji = true;
                    dialog.line.Add(textType);
                    dialog.duckCount++;
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
                    dialog.duckCount++;
                }

                for (int i = 0; i < exceptLaughEmoji; i++)
                {
                    TextType textType = new TextType();
                    textType.text = "<sprite=0>";
                    textType.isEmoji = true;
                    dialog.line.Add(textType);
                    dialog.tankCount++;
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

    }

    public void RemoveMood(float amount)
    {
        currentMood -= amount;

    }

    IEnumerator lose()
    {
        SupremeManager.instance.PlayAnimation("Slam");
        SupremeManager.instance.PlayRedLight();
        yield return new WaitForSeconds(.3f);
        StartCoroutine(camShake.Shake(0.2f, .1f));

        SoundManager.Instance.PlayOneShot("Cage");
        Animator cageAnim = cageObj.GetComponent<Animator>();
        cageAnim.Play("Drop");

        yield return new WaitForSeconds(2f);
        loseUI.SetActive(true);
    }

    IEnumerator win()
    {
        FadingUI.Instance.StartFadeIn();
        dialogObj.SetActive(false);
        laughtBar.SetActive(false);
        debugText.gameObject.SetActive(false);
        yield return new WaitForSeconds(.5f);
        Animator anim = camHolder.GetComponent<Animator>();
        anim.Play("WinCam");
        madel.SetActive(true);
        yield return new WaitForSeconds(.5f);
        FadingUI.Instance.StartFadeOut();
        yield return new WaitForSeconds(4f);
        if (AudioLoudnessDetection.micMode == MicMode.Toggle)
        {
            winUI.SetActive(true);
        }
        else
        {
            secretWinUI.SetActive(true);
        }
        


    }

}
