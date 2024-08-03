
using UnityEngine;

public enum WeaponType
{
    Magic,
    Melee
}

[CreateAssetMenu(fileName = "Weapon_", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite weaponIcon;
    public WeaponType type;
    public float Damage;

    [Header("Projectile")]
    public Projectile projectilePrefab;
    public float RequiredMana;
}
