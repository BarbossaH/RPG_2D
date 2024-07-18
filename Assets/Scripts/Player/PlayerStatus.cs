using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "Player Status")]
public class PlayerStatus : ScriptableObject
{
    [Header("Config")]
    public int Level;
    [Header("Health")]
    public float CurrentHealth;
    public float MaxHealth;
    [Header("Mana")]
    public float CurrentMana;
    public float MaxMana;

    [Header("Exp")]
    public float CurrentExp;
    public float ExpForNextLevel;
    public float InitialNextLevelExp; // if reset player, this variable will be set as default value to upgrade player to level 2
    [Range(1f, 100f)] public float ExpMultiplier;
    public void ResetPlayer()
    {
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;
        Level = 1;
        CurrentExp = 0;
        ExpForNextLevel = InitialNextLevelExp;
    }
}
