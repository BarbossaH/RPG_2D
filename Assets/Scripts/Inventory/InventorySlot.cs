
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private Image quantityBG;
    [SerializeField] private TextMeshProUGUI itemQuantityTMP;

    public int ItemIndex { get; set; }

    public void UpdateSlot(InventoryItem item)
    {
        itemIcon.sprite = item.Icon;
        itemQuantityTMP.text = item.Quantity.ToString();
        if (item.MaxStack <= 1)
        {
            quantityBG.gameObject.SetActive(false);
        }
    }

    public void ShowSlotInformation(bool value)
    {
        itemIcon.gameObject.SetActive(value);
        quantityBG.gameObject.SetActive(value);
    }
}
