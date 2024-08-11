
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon", fileName = "Items/ItemWeapon")]
public class ItemWeapon : InventoryItem
{
  [Header("Weapon")]
  public Weapon Weapon;

  public override void EquipItem()
  {
    base.EquipItem();//actually in the parent class there is nothing in the method.
    WeaponManager.Instance.EquipWeapon(Weapon);
  }
}