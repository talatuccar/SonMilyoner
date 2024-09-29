using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour
{
    public AllAsksDataSo allAsksDataSo;
    [SerializeField] Button answerButton;
    public static event Action<bool> OnResponded;
    int index;
    Image buttonImage;
    private int afterAnsweredWaitTime = 3;
    private void Awake()
    {
        buttonImage = GetComponent<Image>();
    }
    public void IsCorrect(int correctAnswer)
    {
        index = GameController.quesIndex;
        if (correctAnswer == allAsksDataSo.askDataSo[index].correctAnswer)
        {
            CorrectAnswerSettings();
        }
        else
        {
            if (Features.isDoubleReply)
            {
                Features.isDoubleReply = false;
                return;
            }

            WrongAnswerSettings();
        }

        StartCoroutine(AnswerSettings());
    }

    IEnumerator AnswerSettings()
    {
        yield return new WaitForSeconds(afterAnsweredWaitTime);
        buttonImage.color = Color.white;
        NextQuestion();
    }

    void NextQuestion()
    {
        GameController.makeask = true;
    }
    private void CorrectAnswerSettings()
    {

        StopPlayingSFX();
        buttonImage.color = Color.green;
        SFXManager.instance.AnswerSFX(true);
        Features.isJokerChooseable = true;
        OnResponded?.Invoke(true);
    }
    private void WrongAnswerSettings()
    {
        StopPlayingSFX();
        buttonImage.color = Color.red;
        SFXManager.instance.AnswerSFX(false);
        OnResponded?.Invoke(false);
    }
    private void StopPlayingSFX()
    {
        SFXManager.instance.StopForAnswerSFX(); // stop playing question sfx
    }
}
