
public class ScoreModel
{
    private int score;
    public int Score
    {
        get
        {
            if (score < 0)
            {
                score = 0;

            }
            return score;
        }
    }
    public ScoreModel(int initialScore = 1000)
    {
        score = initialScore;
    }
    public void DecreaseScore(int decreaseAmount)
    {
        score -= decreaseAmount;
    }
}
