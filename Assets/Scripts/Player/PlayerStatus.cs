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

    public void ResetPlayer()
    {
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;
    }
}
