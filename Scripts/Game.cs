using DataHolder;
using UnityEngine;


public class Game : MonoBehaviour
{
    [SerializeField] private ScoreView scoreView;
  
    [SerializeField] private Features features;

    [SerializeField]
    private GameData gameData;
    
    private ScoreModel _scoreModel;
    void Start()
    {  
        _scoreModel = new ScoreModel(1000);        

        gameData.Initialize(_scoreModel);
       
        features.Initialize(_scoreModel);

        scoreView.Initialize(_scoreModel);
    }
}
