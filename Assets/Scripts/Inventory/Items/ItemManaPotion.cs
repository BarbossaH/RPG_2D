
using UnityEngine;
[CreateAssetMenu(fileName = "ItemManaPotion", menuName = "Items/Mana Potion")]
public class ItemManaPotion : InventoryItem
{
  [Header("Config")]
  public float ManaValue;

  public override bool UseItem()
  {
    bool canUseItem = GameManager.Instance.Player.PlayerMana.CanRestoreMana();
    if (canUseItem)
    {
      GameManager.Instance.Player.PlayerMana.RestoreMana(ManaValue);
    }
    return canUseItem;
  }
}
