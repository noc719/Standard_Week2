using UnityEngine;

[CreateAssetMenu(fileName ="MonsterQuestDataSO",menuName = "ScriptableObject/QuestDataSO/Monster",order = 1)]
public class MonsterQuestDataSO : QuestDataSO
{
    [Header("Monster")]
    public string monsterName;
}
