using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllAsksData", menuName = "AllAsksDataSo")]
public class AllAsksDataSo : ScriptableObject
{
    public List<AskDataSo> askDataSo;
}
