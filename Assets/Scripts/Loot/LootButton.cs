using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootButton : MonoBehaviour
{
    //this class is for show one of the drop items information and set a click event when player collect the item.
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemQuantity;

    public DropItem ItemLoaded { get; private set; }

    public void ConfigLootButton(DropItem dropItem)
    {
        ItemLoaded = dropItem;
        itemIcon.sprite = dropItem.item.Icon;
        itemName.text = dropItem.item.Name;
        itemQuantity.text = $"X {dropItem.Quantity.ToString()}";
    }

    public void OnClickCollectItem()
    {
        if (ItemLoaded != null) return;
        InventoryManager.Instance.AddItem(ItemLoaded.item, ItemLoaded.Quantity);
        ItemLoaded.PickedItem = true;
        Destroy(gameObject);
    }
}
