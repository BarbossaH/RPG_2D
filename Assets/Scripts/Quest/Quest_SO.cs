
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

    //this class includes some method to deal with the change of the quest states
    public void AddProgress(int amount)
    {
        CurrentStatus += amount;
        if (CurrentStatus >= QuestGoal)
        {
            CurrentStatus = QuestGoal;
            QuestIsCompleted();
        }
    }

    private void QuestIsCompleted()
    {
        if (QuestCompleted) { return; }
        QuestCompleted = true;
    }

    public void ResetQuest()
    {
        QuestAccepted = false;
        QuestCompleted = false;
        CurrentStatus = 0;
    }


}

[Serializable]
public class QuestItemReward
{
    public InventoryItem Item;
    public int Quantity;
}