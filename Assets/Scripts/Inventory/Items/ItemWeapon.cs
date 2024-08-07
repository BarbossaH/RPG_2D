
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon", fileName = "Items/ItemWeapon")]
public class ItemWeapon : InventoryItem
{
  [Header("Weapon")]
  public Weapon weapon;
}