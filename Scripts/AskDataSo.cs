using UnityEngine;

[CreateAssetMenu(fileName = "quesitonData", menuName = "questionDataSo")]
public class AskDataSo : ScriptableObject
{
    [TextArea]
    public string question;
    [TextArea]
    public string[] answers;
    public int correctAnswer;
    public int timeValue;
}
