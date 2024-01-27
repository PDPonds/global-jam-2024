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

    }

    private void Update()
    {


        if (AudioLoudnessDetection.isDisable)
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
                muteCooldonw = 1.0f;
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
        SoundManager.Instance.PlayOneShot("Click");

    }

    private void GoToGameScene() 
    {
        SoundManager.Instance.Stop("BGM");
        SoundManager.Instance.Play("BGM2");
        SceneManager.LoadScene("SampleScene");
    }
}
