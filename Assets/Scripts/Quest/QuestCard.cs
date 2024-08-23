
using TMPro;
using UnityEngine;

public class QuestCard : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI questNameTMP;
  [SerializeField] private TextMeshProUGUI questDescriptionTMP;

  public Quest_SO QuestToComplete { get; set; } //quest data, it is a parameter for being passed into acceptQuest function

  public virtual void ConfigureQuestUI(Quest_SO quest)
  {
    QuestToComplete = quest;
    Debug.Log(QuestToComplete);
    questNameTMP.text = quest.Name;
    questDescriptionTMP.text = quest.Description;
  }
}
