using UnityEngine;

[CreateAssetMenu(fileName = "JokerCostDataSO", menuName = "ScriptableObjects/JokerCostDataSO", order = 1)]
public class JokerCostDataSO : ScriptableObject
{
    public int extraTime = 30;
    public int halfJokerCost = 100;
    public int changeAskCost = 125;
    public int extraTimeCost = 75;
    public int doubleReplyCost = 150;
    public int wrongAnswerCost = 200;
}
