using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    //this class is for show items and other functions. for controlling slot
    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private Transform container;

    private List<InventorySlot> slotList = new List<InventorySlot>();
    private int inventorySize;

    private void Start()
    {
        inventorySize = InventoryManager.Instance.InventorySize;
        InitInventory();
    }
    private void InitInventory()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            InventorySlot slot = Instantiate(slotPrefab, container);
            slot.ItemIndex = i;
            slotList.Add(slot);
        }
    }

    public void DrawItemSlot(InventoryItem item, int index)
    {
        slotList[index].ShowSlotInformation(true);
        slotList[index].UpdateSlot(item);
    }
}
