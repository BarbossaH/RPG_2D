using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : Singleton<LootManager>
{
    [Header("Config")]
    [SerializeField] private GameObject lootPanel;
    [SerializeField] private LootButton lootButtonPrefab;
    [SerializeField] private Transform container;

    public void ShowLoot(EnemyLoot loot)
    {
        //to get the drop items and show them on the panel
        lootPanel.SetActive(true);
        //clear the last drop items information
        if (LootPanelWithItems())
        {
            for (int i = 0; i < container.childCount; i++)
            {
                Destroy(container.GetChild(i).gameObject);
            }
        }

        foreach (DropItem item in loot.DropItems)
        {
            if (item.PickedItem) continue;
            LootButton lootButton = Instantiate(lootButtonPrefab, container);
            lootButton.ConfigLootButton(item);
        }
    }

    public void OnClickClosePanel()
    {
        lootPanel.SetActive(false);
    }
    private bool LootPanelWithItems() { return container.childCount > 0; }
}
