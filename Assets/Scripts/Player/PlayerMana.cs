using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStatus playerStatus;

    private void Start()
    {
        ResetMana();
    }
    public void UseMana(float amount)
    {
        playerStatus.CurrentMana = Mathf.Max(0f, playerStatus.CurrentMana - amount);
    }
    public bool CanRestoreMana()
    {
        return playerStatus.CurrentMana < playerStatus.MaxMana && playerStatus.CurrentHealth > 0;
    }

    public void RestoreMana(float amount)
    {
        playerStatus.CurrentMana += amount;
        if (playerStatus.CurrentMana > playerStatus.MaxMana)
        {
            playerStatus.CurrentMana = playerStatus.MaxMana;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UseMana(1f);
        }
    }

    public void ResetMana()
    {
        playerStatus.CurrentMana = playerStatus.MaxMana;
    }
}
