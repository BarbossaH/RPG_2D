using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributesType
{
    Strength,
    Dexterity,
    Intelligence
}
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

    [Header("Attack")]
    public float BaseDamage;
    public float CriticalChance;
    public float CriticalDamage;

    [Header("Attributes")]
    public int Strength;
    public int Dexterity;
    public int Intelligence;
    public int AttributesPoints;

    [HideInInspector] public float TotalExp;
    [HideInInspector] public float TotalDamage;
    public void ResetPlayer()
    {
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;
        Level = 1;
        CurrentExp = 0;
        ExpForNextLevel = InitialNextLevelExp;
        TotalExp = 0;
        BaseDamage = 2;
        CriticalChance = 10;
        CriticalDamage = 50;
        Strength = 0;
        Intelligence = 0;
        Dexterity = 0;
        AttributesPoints = 0;
    }
}
