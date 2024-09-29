using DataHolder;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
public class GameController : MonoBehaviour
{
    public static event Action<bool> OnNextQuestion;

    public AllAsksDataSo allAsksDataSo;
    private int _currentAsk = 0;

    public static bool makeask;

    [SerializeField]
    TextMeshProUGUI quesText;
    [SerializeField]
    TextMeshProUGUI[] answerTexts;

    [SerializeField] private TextMeshProUGUI quesOrderText;

    [SerializeField] private GameData gameData;

    public static int quesIndex;
    void Start()
    {
        StartCoroutine(PrepareQuestions());
    }
    IEnumerator PrepareQuestions()
    {
        for (int i = 0; i < allAsksDataSo.askDataSo.Count; i++)
        {
            PlayAskSFX();
            OnNextQuestion?.Invoke(true);
            quesIndex = i;
            UpdateQuesOrder();

            quesText.text = allAsksDataSo.askDataSo[i].question;
            _currentAsk = 0;
            foreach (string answer in allAsksDataSo.askDataSo[i].answers)
            {
                answerTexts[_currentAsk].text = answer;
                _currentAsk++;
                makeask = false;

            }
            yield return new WaitUntil(() => makeask);

        }

        gameData.OpenLeaderBoard();
    }
    void PlayAskSFX()
    {
        if (quesIndex < 11)
        {
            SFXManager.instance.EasyAskSFX();
        }
        else
        {
            SFXManager.instance.HardAskSFX();
        }
    }

    void UpdateQuesOrder()
    {
        quesOrderText.text=(quesIndex+1).ToString() + "/" + allAsksDataSo.askDataSo.Count.ToString();
    }
}
