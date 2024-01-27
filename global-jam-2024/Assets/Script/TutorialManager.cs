using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _tutorialList = new List<GameObject>();
    [SerializeField]
    List<Button> _nextButtonList = new List<Button>();
    private int currentIndex = 0;

    private void Start()
    {
        foreach (Button _button in _nextButtonList) 
        {
            _button.onClick.AddListener(Next);
        }
    }

    public void Next() 
    {
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
