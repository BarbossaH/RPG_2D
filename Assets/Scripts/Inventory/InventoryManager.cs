
using System.Collections.Generic;
using UnityEngine;
//this class is responsible for manage the data of items, such use, remove, and equip items
public class InventoryManager : Singleton<InventoryManager>
{
    [Header("Config")]
    [SerializeField] private int inventorySize;
    [SerializeField] private InventoryItem[] inventoryItems;
    [Header("Testing")]
    public InventoryItem testItm;
    public int InventorySize => inventorySize;

    private void Start()
    {
        inventoryItems = new InventoryItem[inventorySize];
        VerifyItemsForDraw();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // inventoryItems[0] = testItm.CopyItem();
            // inventoryItems[0].Quantity = 10;
            // InventoryUI.Instance.DrawItemSlot(inventoryItems[0], 0);
            AddItem(testItm, 6);
        }
    }
    public void UseItem(int index)
    {
        if (inventoryItems[index] == null) return;
        if (inventoryItems[index].UseItem())
        {
            DecreaseItemStack(index);
        }
    }

    public void RemoveItem(int index)
    {
        if (inventoryItems[index] == null) return;
        inventoryItems[index].RemoveItem();
        inventoryItems[index] = null;
        InventoryUI.Instance.DrawItemSlot(null, index);
    }

    public void EquipItem(int index)
    {
        if (inventoryItems[index] == null) return;
        if (inventoryItems[index].ItemType != ItemType.Weapon) return;
        inventoryItems[index].EquipItem();
    }
    public void AddItem(InventoryItem item, int quantity)
    {
        //prioritize stacking items onto stacks of the same type. If the stacks of the same type are full, them stack items in empty slots. If there are not enough space after utilizing the available slots, apply special handling procedures.

        if (item == null && quantity <= 0) return;
        int restAmount = quantity;

        if (item.IsStackable)
        {
            List<int> itemIndexes = CheckItemStock(item.ID);
            if (itemIndexes.Count > 0)
            {
                //if there are same type items
                int maxStack = item.MaxStack;

                foreach (int index in itemIndexes)
                {
                    if (inventoryItems[index].Quantity < maxStack)
                    {
                        int capacity = maxStack - inventoryItems[index].Quantity;
                        if (capacity >= restAmount)
                        {
                            inventoryItems[index].Quantity += restAmount;
                        }
                        else
                        {
                            inventoryItems[index].Quantity = maxStack;
                        }
                        InventoryUI.Instance.DrawItemSlot(inventoryItems[index], index);
                        restAmount -= capacity;
                        if (restAmount <= 0) return;
                    }
                }
            }
        }
        AddItemFreeSlot(item, restAmount);
    }

    private void DecreaseItemStack(int index)
    {
        inventoryItems[index].Quantity--;
        if (inventoryItems[index].Quantity <= 0)
        {
            inventoryItems[index] = null;
        }
        InventoryUI.Instance.DrawItemSlot(inventoryItems[index], index);
    }
    private List<int> CheckItemStock(string itemID)
    {
        List<int> itemIndexes = new List<int>();
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i] == null) continue;
            if (inventoryItems[i].ID == itemID)
            {
                itemIndexes.Add(i);
            }
        }
        return itemIndexes;
    }

    private bool AddItemFreeSlot(InventoryItem item, int quantity)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            if (inventoryItems[i] != null) continue;
            inventoryItems[i] = item.CopyItem();
            if (quantity <= item.MaxStack)
            {
                inventoryItems[i].Quantity = quantity;
                InventoryUI.Instance.DrawItemSlot(inventoryItems[i], i);
                return true;
            }
            else
            {
                inventoryItems[i].Quantity = item.MaxStack;
                InventoryUI.Instance.DrawItemSlot(inventoryItems[i], i);
                int restAmount = quantity - item.MaxStack;
                if (restAmount > 0)
                {
                    bool isFinished = AddItemFreeSlot(item, restAmount);
                    if (isFinished) return true;
                }
            }

        }
        return false;
    }

    private void VerifyItemsForDraw()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            if (inventoryItems[i] == null)
            {
                InventoryUI.Instance.DrawItemSlot(null, i);
            }
        }
    }
}
