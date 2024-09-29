using TMPro;
using UnityEngine;
public class TimeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField]
    private GameObject leaderboardPanel;
    [SerializeField] private AllAsksDataSo allAsksDataSo;
    public static float timeValue;
    private int _currentAsk;
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;

            timerText.text = timeValue.ToString("00");
        }

        CheckTýme();
    }
    void CheckTýme()
    {
        if (timeValue <= 10)
        {
            timerText.color = Color.red;
            if (timerText.text == "00")
            {
                SFXManager.instance.TimeIsUpSFX();
                leaderboardPanel.SetActive(true);
                TextMeshProUGUI textComponent = leaderboardPanel.GetComponentInChildren<TextMeshProUGUI>();
                textComponent.fontSize = Screen.height*0.5f;
                textComponent.enableAutoSizing = true;
                textComponent.text = "TIME IS UP"; 

            }

        }
        else
        {
            timerText.color = Color.white;
        }
    }
    void NextQuestionTime(bool isNext)
    {
        if (isNext)
        {
            if (_currentAsk == 0)
            {
                SetAskTime(_currentAsk);
                _currentAsk++;
                return;
            }

            SetAskTime(_currentAsk);
            _currentAsk++;
        }
    }
    void ChangedAskTime()
    {
        NextQuestionTime(false);

        _currentAsk = GameController.quesIndex;
        _currentAsk++;

        print(_currentAsk);
        SetAskTime(_currentAsk);
    }
    void SetAskTime(int askIndex)
    {
        timeValue = allAsksDataSo.askDataSo[askIndex].timeValue;
    }
    private void OnEnable()
    {
        GameController.OnNextQuestion += NextQuestionTime;
        Features.OnChangedTime += ChangedAskTime;

    }
    private void OnDisable()
    {
        GameController.OnNextQuestion -= NextQuestionTime;
        Features.OnChangedTime -= ChangedAskTime;
    }
}
