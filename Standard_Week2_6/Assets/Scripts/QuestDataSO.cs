using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "QuestDataSO",menuName ="ScriptableObject/QuestDataSO",order =0)]
public class QuestDataSO : ScriptableObject 
{
    [Header("Quest")]
    public string QuestName;
    public int QuestRequiredLevel;
    public int QuestNPC;

    private List<int> QuestPrerequisites = new List<int>();
}
