using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
  [Header("Quests")]
  [SerializeField] private Quest_SO[] quests;
  [Header("NPC Quest Panel")]
  [SerializeField] private QuestCardNpc questCardNpcPrefab;
  [SerializeField] private Transform npcPanelContainer;

  [Header("Player Quest Panel")]
  [SerializeField] private QuestCardPlayer questCardPlayerPrefab;
  [SerializeField] private Transform playerPanelContainer;
  private void Start()
  {
    LoadQuestIntoNPCPanel();
  }

  public void AcceptQuest(Quest_SO quest)
  {
    //this function is responsible for creating the accept quest ui due to the parameter Quest
    QuestCardPlayer questCardPlayer = Instantiate(questCardPlayerPrefab, playerPanelContainer);
    questCardPlayer.ConfigureQuestUI(quest);
  }
  public void AddProgress(string questID, int amount)
  {
    Quest_SO quest = GetQuestByID(questID);
    if (quest != null && quest.QuestAccepted)
    {
      quest.AddProgress(amount);
    }
  }
  private Quest_SO GetQuestByID(string questID)
  {
    foreach (Quest_SO quest in quests)
    {
      if (quest.ID == questID)
      {
        return quest;
      }
    }
    return null;
  }
  private void LoadQuestIntoNPCPanel()
  {
    for (int i = 0; i < quests.Length; i++)
    {
      QuestCard npcCard = Instantiate(questCardNpcPrefab, npcPanelContainer);
      npcCard.ConfigureQuestUI(quests[i]);
    }
  }

  private void OnEnable()
  {
    foreach (Quest_SO quest in quests)
    {
      quest.ResetQuest();
    }
  }
}