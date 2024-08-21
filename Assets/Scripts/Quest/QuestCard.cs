
using TMPro;
using UnityEngine;

public class QuestCard : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI questNameTMP;
  [SerializeField] private TextMeshProUGUI questDescriptionTMP;

  public Quest_SO QuestToComplete { get; set; }

  public virtual void ConfigureQuestUI(Quest_SO quest)
  {
    QuestToComplete = quest;
    questNameTMP.text = quest.Name;
    questDescriptionTMP.text = quest.Description;
  }
}
