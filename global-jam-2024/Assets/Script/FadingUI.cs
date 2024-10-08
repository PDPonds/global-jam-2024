using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
public enum FadingPhase
{
    FadeIn,
    FadeOut
}

public class FadingUI : MonoBehaviour
{
    private static FadingUI _instance;

    public static FadingUI Instance
    {
        get
        {
            if (_instance == null && Application.isPlaying)
            {
                GameObject obj = new GameObject("FadingUI");
                FadingUI comp = obj.AddComponent<FadingUI>();
                _instance = comp;
            }

            return _instance;
        }
    }

    [SerializeField]
    private Image fadeImage;

    [SerializeField]
    private TextMeshProUGUI _currentSoundValue;

    [SerializeField]
    private TextMeshProUGUI _currentSoundThreshold;


    [SerializeField]
    private Image micImage;

    public UnityEvent OnStopFading;
    private bool fading;
    private FadingPhase currentFadingPhase;

    [SerializeField] private float fadingSpeed;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
        OnActiveSceneChanged();
    }

    private void Update()
    {
        if (fading) 
        {
            if (currentFadingPhase == FadingPhase.FadeIn)
            {
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a + Time.deltaTime * fadingSpeed);
                
                if (fadeImage.color.a >= 1) 
                {
                    StopFading();
                }
            }
            else
            {
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a - Time.deltaTime * fadingSpeed);

                if (fadeImage.color.a <= 0)
                {
                    StopFading();
                }
            }
        }

        AudioLoudnessDetection.HandleMute();

        micImage.gameObject.SetActive(!AudioLoudnessDetection.isMute);

        _currentSoundValue.text = ((Mathf.Round(AudioLoudnessDetection.GetLoudnessFromMicrophone() * 100f)) / 100.0f).ToString();
        _currentSoundThreshold.text = ((Mathf.Round(AudioLoudnessDetection.Threshold * 100f)) / 100.0f).ToString();
    }

    public void StartFadeIn() 
    {
        fadeImage.gameObject.SetActive(true);
        fading = true;
        currentFadingPhase = FadingPhase.FadeIn;
    }

    public void StartFadeOut()
    {
        fadeImage.gameObject.SetActive(true);
        fading = true;
        currentFadingPhase = FadingPhase.FadeOut;
    }

    private void StopFading() 
    {
        fading = false;
        OnStopFading?.Invoke();
        OnStopFading.RemoveAllListeners();
    }

    private void OnActiveSceneChanged() 
    {
        SceneManager.activeSceneChanged += DisactiveFadeImage;
    }

    private void DisactiveFadeImage(Scene current, Scene next) 
    {
        fadeImage.gameObject.SetActive(false);
    }
}
