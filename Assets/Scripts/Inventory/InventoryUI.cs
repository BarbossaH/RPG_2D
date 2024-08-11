using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    //this class is for show items and other functions. for controlling slot
    [Header("Config")]
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private Transform container;

    public InventorySlot CurrentSlot { get; set; }
    private List<InventorySlot> slotList = new List<InventorySlot>();
    private int inventorySize;

    protected override void Awake()
    {
        base.Awake();
        inventorySize = InventoryManager.Instance.InventorySize;
        InitInventory();
    }
    private void Start()
    {
        inventorySize = InventoryManager.Instance.InventorySize;
        // InitInventory();
    }
    private void InitInventory()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            InventorySlot slot = Instantiate(slotPrefab, container);
            slot.SlotIndex = i;
            slotList.Add(slot);
        }
    }
    public void OnUseItemClickEvent()
    {
        InventoryManager.Instance.UseItem(CurrentSlot.SlotIndex);
    }
    public void DrawItemSlot(InventoryItem item, int index)
    {
        if (item == null)
        {
            // slotList[index].ShowSlotInformation(false);

            return;
        }
        slotList[index].ShowSlotInformation(true);
        slotList[index].UpdateSlot(item);
    }

    public void OpenCloseInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
    public void RemoveItem()
    {
        if (CurrentSlot == null) return;
        InventoryManager.Instance.RemoveItem(CurrentSlot.SlotIndex);
    }

    public void EquipItem()
    {
        if (CurrentSlot == null) return;
        InventoryManager.Instance.EquipItem(CurrentSlot.SlotIndex);
    }
    private void OnSelectSlotCallback(int index)
    {
        CurrentSlot = slotList[index];
    }

    private void OnEnable()
    {
        InventorySlot.OnSlotSelectedEvent += OnSelectSlotCallback;
    }
    private void OnDisable()
    {
        InventorySlot.OnSlotSelectedEvent -= OnSelectSlotCallback;
    }
}
