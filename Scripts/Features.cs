using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Features : MonoBehaviour
{
    [SerializeField] Button[] answerButtons;

    [SerializeField] private AllAsksDataSo allAsksDataSo;

    [SerializeField] private JokerCostDataSO jokerCostDataSO;

    [SerializeField] Button[] jokerButtons;

    ScoreModel scoreModel;

    public static event Action OnChangedTime;

    public static bool isJokerChooseable = false;
    public static bool isDoubleReply = false;

    int random1;

    int random2;
    private int _correctAnswerIndex { get; set; }
    private int _questionIndex = 0;
    public void Initialize(ScoreModel scoreModel)
    {
        this.scoreModel = scoreModel;

    }
    public void ChangeAskJoker()
    {
        OnChangedTime?.Invoke();
        scoreModel.DecreaseScore(jokerCostDataSO.changeAskCost);
        GameController.makeask = true;
    }
    public void DoubleReply()
    {
        if (CanUseJoker(jokerCostDataSO.doubleReplyCost))
        {
            DeactiveUsedJoker(jokerButtons[2]);
            isDoubleReply = true;
            // If this joker has been used, ignore the first wrong answer.
            scoreModel.DecreaseScore(jokerCostDataSO.doubleReplyCost);
            GameController.makeask = false;
        }
        else
        {
            DeactiveUsedJoker(jokerButtons[2]);
        }

    }
    public void HalfJoker()
    {
        if (CanUseJoker(jokerCostDataSO.halfJokerCost))
        {
            HalfJokerSettings();
            List<int> indexler = new List<int> { 0, 1, 2, 3 }; // list of all potential answers

            _questionIndex = GameController.quesIndex;
            _correctAnswerIndex = allAsksDataSo.askDataSo[_questionIndex].correctAnswer - 1;

            indexler.Remove(_correctAnswerIndex);

            // Disable 2 random wrong answer buttons
            int randomIndex = Random.Range(0, answerButtons.Length - 1);
            int random1 = indexler[randomIndex];

            indexler.RemoveAt(randomIndex);

            int randomIndex2 = Random.Range(0, answerButtons.Length - 2);

            int random2 = indexler[randomIndex2];

            answerButtons[random2].GetComponent<Button>().interactable = false;

            answerButtons[random1].GetComponent<Button>().interactable = false;
        }
        else
        {
            DeactiveUsedJoker(jokerButtons[0]); //Not enough points to get Joker
        }
    }
    private void HalfJokerSettings()
    {
        DeactiveUsedJoker(jokerButtons[0]);
        SFXManager.instance.HalfJokerSFX();
        scoreModel.DecreaseScore(jokerCostDataSO.halfJokerCost);
    }
    public void ExtraTýmeJoker()
    {
        if (CanUseJoker(jokerCostDataSO.extraTimeCost))
        {
            DeactiveUsedJoker(jokerButtons[3]);
            scoreModel.DecreaseScore(jokerCostDataSO.extraTimeCost);
            TimeManager.timeValue += jokerCostDataSO.extraTime;
        }
        else
        {
            DeactiveUsedJoker(jokerButtons[3]);
        }
    }
    void ResetJokerButtons(bool isClickable)
    {
        if (!isClickable)
        {
            scoreModel.DecreaseScore(jokerCostDataSO.wrongAnswerCost);
        }

        if (isJokerChooseable)
            isClickable = false;

        foreach (var item in jokerButtons)
        {
            item.enabled = isClickable;
        }

        isJokerChooseable = false;
    }
    private void DeactiveUsedJoker(Button jokerButton)
    {
        // each Joker can only be used once for each question.
        jokerButton.GetComponent<Button>().enabled = false;
    }

    private bool CanUseJoker(int jokerCost)
    {
        return scoreModel.Score > 0 && scoreModel.Score >= jokerCost;
    }
    private void OnEnable()
    {
        GameController.OnNextQuestion += ResetJokerButtons;
        ButtonController.OnResponded += ResetJokerButtons;
    }
    private void OnDisable()
    {
        GameController.OnNextQuestion -= ResetJokerButtons;
        ButtonController.OnResponded -= ResetJokerButtons;
    }
}
