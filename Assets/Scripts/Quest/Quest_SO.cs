
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest_")]
public class Quest_SO : ScriptableObject
{
    //this class is for forming the quest data structure
    [Header("Info")]
    public string Name;
    public string ID;
    public int QuestGoal;

    [Header("Description")]
    [TextArea] public string Description;
    public int GoldReward;
    public float ExpReward;
    public QuestItemReward QuestItemReward;

    [HideInInspector] public int CurrentStatus;
    [HideInInspector] public bool QuestCompleted;
    [HideInInspector] public bool QuestAccepted;
}

[Serializable]
public class QuestItemReward
{
    public InventoryItem Item;
    public int Quantity;
}