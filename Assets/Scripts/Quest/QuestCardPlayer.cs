using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestCardPlayer : QuestCard
{
  [Header("Config")]
  [SerializeField] private TextMeshProUGUI statusTMP;
  [SerializeField] private TextMeshProUGUI goldRewardMP;
  [SerializeField] private TextMeshProUGUI expRewardTMP;

  [SerializeField] private Image itemIcon;
  [SerializeField] private TextMeshProUGUI itemQuantityTMP;
  private void Update()
  {
    // Debug.Log(QuestToComplete);
    if (QuestToComplete == null) return;
    // if (QuestToComplete.QuestCompleted) return;
    statusTMP.text = $"Status\n{QuestToComplete.CurrentStatus}/{QuestToComplete.QuestGoal}";
  }
  public override void ConfigureQuestUI(Quest_SO quest)
  {
    base.ConfigureQuestUI(quest);
    statusTMP.text = $"Status\n{quest.CurrentStatus}/{quest.QuestGoal}";
    goldRewardMP.text = quest.GoldReward.ToString();
    expRewardTMP.text = quest.ExpReward.ToString();

    itemIcon.sprite = quest.QuestItemReward.Item.Icon;
    itemQuantityTMP.text = quest.QuestItemReward.Quantity.ToString();
  }
}