using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialogue : Dialog
{
    [SerializeField]
    private GameObject _onDialogueDone;
    
    void Start()
    {
        ActiveDialog();
    }

    private void Update()
    {
        if (CheckAllTextInDialog()) 
        {
            OnDialogueEnd();
        }
    }

    private void OnDialogueEnd() 
    {
        if (_onDialogueDone != null) 
        {
            _onDialogueDone.SetActive(true);
        }
    }
}
