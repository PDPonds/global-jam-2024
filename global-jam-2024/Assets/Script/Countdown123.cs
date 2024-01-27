using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown123 : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private float _startCountDownTime = 3f;

    private float _currentTime;

    private bool _isCountingDown;

    private void Start()
    {
        StartCounting();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
    }
    void Update()
    {
        if (_isCountingDown) 
        {
            _currentTime -= Time.deltaTime;
            _text.text = _currentTime.ToString("0");

            if (_currentTime <= 0) 
            {
                TimeOver();
            }
        }
    }

    public void StartCounting() 
    {
        _isCountingDown = true;
        _currentTime = _startCountDownTime;
    }

    private void TimeOver() 
    {
        _isCountingDown = false;
    }
}
