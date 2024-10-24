using UnityEngine;

[CreateAssetMenu(fileName ="EncounterQuestDataSO",menuName = "ScriptableObject/QuestDataSO/Encounter",order =2)]
public class EncounterQuestDataSO : QuestDataSO
{
    [Header("Encounter")]
    public int encounterId;
}