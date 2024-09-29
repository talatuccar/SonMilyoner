using TMPro;
using UnityEngine;
public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    ScoreModel _scoreModel;
    public void Initialize(ScoreModel scoreModel)
    {
        _scoreModel = scoreModel;
        scoreText.text = _scoreModel.Score.ToString();
    }
    void Update()
    {
        scoreText.text = _scoreModel.Score.ToString();
    }
}