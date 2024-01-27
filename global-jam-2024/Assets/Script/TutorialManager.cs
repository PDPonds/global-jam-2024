using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _tutorialList = new List<GameObject>();
    [SerializeField]
    List<Button> _nextButtonList = new List<Button>();
    private int currentIndex = 0;
    private float muteCooldonw = 1.0f;

    private void Start()
    {
        foreach (Button _button in _nextButtonList) 
        {
            _button.onClick.AddListener(Next);
        }
    }

    private void Update()
    {


        if (AudioLoudnessDetection.isMute)
        {
            muteCooldonw -= Time.deltaTime;
            if (muteCooldonw <= 0)
            {
                AudioLoudnessDetection.SetMute(false);
            }
        }
        else 
        {
            if (AudioLoudnessDetection.IsMoreThanThreshold() || Input.GetKeyDown("space"))
            {
                Next();
                AudioLoudnessDetection.SetMute(true);
                muteCooldonw = 3.0f;
            }
        }
    }

    public void Next() 
    {
        if (currentIndex > _tutorialList.Count - 1) 
        {
            return;
        }

        _tutorialList[currentIndex].SetActive(false);
        currentIndex++;
        if (currentIndex >= _tutorialList.Count)
        {
            FadingUI.Instance.OnStopFading.AddListener(GoToGameScene);
            FadingUI.Instance.StartFadeIn();
        }
        else 
        {
            _tutorialList[currentIndex].SetActive(true);
        }

    }

    private void GoToGameScene() 
    {
        SceneManager.LoadScene("SampleScene");
    }
}
