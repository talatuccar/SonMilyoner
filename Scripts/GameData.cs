using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DataHolder
{
    public class GameData : MonoBehaviour
    {
        public GameObject leaderBoard;

        ScoreModel scoreModel;

        [SerializeField]
        private TextMeshProUGUI[] nameTexts;
        private int resultScore { get; set; }

        List<PlayerScore> playerScores = new List<PlayerScore>();
        public void Initialize(ScoreModel scoreModel)
        {
            this.scoreModel = scoreModel;
        }
        public void OpenLeaderBoard()
        {
            Time.timeScale = 0;
            leaderBoard.SetActive(true);
            resultScore = scoreModel.Score;

            string playerName = PlayerPrefs.GetString("playerName");
            SaveScore(playerName, resultScore);
            LoadScores();
        }
        private void SaveScore(string playerName, int score)
        {

            int playerCount = PlayerPrefs.GetInt("playerCount", 0);

            PlayerPrefs.SetString("playerName_" + playerCount, playerName);
            PlayerPrefs.SetInt("playerScore_" + playerCount, score);
            PlayerPrefs.SetInt("playerCount", playerCount + 1);
        }
        private void LoadScores()
        {
            int playerCount = PlayerPrefs.GetInt("playerCount", 0);
            List<PlayerScore> playerScores = new List<PlayerScore>();

            for (int i = 0; i < playerCount; i++)
            {
                string name = PlayerPrefs.GetString("playerName_" + i);
                int score = PlayerPrefs.GetInt("playerScore_" + i);
                playerScores.Add(new PlayerScore(name, score));
            }

            playerScores.Sort((a, b) => b.score.CompareTo(a.score));

            for (int i = 0; i < playerScores.Count && i < nameTexts.Length; i++)
            {
                nameTexts[i].text = playerScores[i].playerName + " = " + playerScores[i].score.ToString();
            }
        }
        public void MainMenu()
        {
            SceneManager.LoadScene(0);
        }
        public class PlayerScore
        {
            public string playerName;
            public int score;

            public PlayerScore(string name, int score)
            {
                playerName = name;
                this.score = score;
            }
        }
    }
}