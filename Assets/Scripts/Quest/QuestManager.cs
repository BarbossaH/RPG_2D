using UnityEngine;

public class QuestManager : MonoBehaviour
{
  [Header("Quests")]
  [SerializeField] private Quest_SO[] quests;
  [SerializeField] private QuestCardNpc questCardNpcPrefab;
  [SerializeField] private Transform npcPanelContainer;

  private void Start()
  {
    LoadQuestIntoNPCPanel();
  }
  private void LoadQuestIntoNPCPanel()
  {
    for (int i = 0; i < quests.Length; i++)
    {
      QuestCard npcCard = Instantiate(questCardNpcPrefab, npcPanelContainer);
      npcCard.ConfigureQuestUI(quests[i]);
    }
  }
}