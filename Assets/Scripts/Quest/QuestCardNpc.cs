using TMPro;
using UnityEngine;
public class QuestCardNpc : QuestCard
{
  [SerializeField] private TextMeshProUGUI questRewardTMP;

  public override void ConfigureQuestUI(Quest_SO quest)
  {
    base.ConfigureQuestUI(quest);
    questRewardTMP.text = $"- {quest.GoldReward}  Gold\n" + $"- {quest.ExpReward}  Exp\n" + $"- {quest.QuestItemReward.Item.Name}  X  {quest.QuestItemReward.Quantity}";
  }
}