
using UnityEngine;
[CreateAssetMenu(fileName = "ItemHealthPotion", menuName = "Items/Health Potion")]
public class ItemHealthPotion : InventoryItem
{
    [Header("Config")]
    public float HealthValue;

    public override bool UseItem()
    {
        bool canUseItem = GameManager.Instance.Player.PlayerHealth.CanRestoreHealth();
        if (canUseItem)
        {
            GameManager.Instance.Player.PlayerHealth.RestoreHealth(HealthValue);
        }
        return canUseItem;
    }
}
