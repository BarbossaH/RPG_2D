using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "Player Status")]
public class PlayerStatus : ScriptableObject
{
    [Header("Config")]
    public int Level;
    [Header("Health")]
    public int MaxHealth;
    public int CurrentHealth;
}
