using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button[] allButtons;

    [SerializeField] AllAsksDataSo allAsksDataSo;
    void ResetButtons(bool clickable) // reset answer buttons for the next question
    {
        foreach (var item in allButtons)
        {
            Button resetButton = item.GetComponent<Button>();
            resetButton.enabled = clickable;

            if (clickable)
            {
                allButtons[allAsksDataSo.askDataSo[GameController.quesIndex].correctAnswer - 1].GetComponent<Image>().color = Color.white;
   
                if (!resetButton.interactable == true)
                {
                    resetButton.interactable = true;
                }
            }
        }
    }

    void WrongAnswerColor(bool isCorrect)
    {
        if (!isCorrect)
            allButtons[allAsksDataSo.askDataSo[GameController.quesIndex].correctAnswer - 1].GetComponent<Image>().color = Color.green;
        ResetButtons(false);
    }
    private void OnEnable()
    {
        GameController.OnNextQuestion += ResetButtons;
        ButtonController.OnResponded += WrongAnswerColor;
    }
    private void OnDisable()
    {
        GameController.OnNextQuestion -= ResetButtons;
        ButtonController.OnResponded -= WrongAnswerColor;
    }

}
