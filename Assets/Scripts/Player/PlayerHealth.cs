using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerStatus playerStatus;

    public bool IsPlayerDead { get; private set; }
    private PlayerAnimations playerAnimations;

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            IsPlayerDead = false;
        }
    }
    public void TakeDamage(float damage)
    {
        playerStatus.CurrentHealth -= damage;
        DamageTextManger.Instance.ShowDamageText(damage, transform);
        // Debug.Log(playerStatus.CurrentHealth);
        if (playerStatus.CurrentHealth <= 0)
        {
            playerStatus.CurrentHealth = 0;
            SetPlayerDeath();
        }
    }
    public bool CanRestoreHealth()
    {
        return playerStatus.CurrentHealth > 0 && playerStatus.CurrentHealth < playerStatus.MaxHealth;
    }
    public void RestoreHealth(float amount)
    {
        playerStatus.CurrentHealth += amount;
        if (playerStatus.CurrentHealth >= playerStatus.MaxHealth)
        {
            playerStatus.CurrentHealth = playerStatus.MaxHealth;
        }
        // playerStatus.CurrentHealth = Mathf.Min(playerStatus.CurrentHealth + amount, playerStatus.MaxHealth);
    }
    private void SetPlayerDeath()
    {
        IsPlayerDead = true;
        playerAnimations.SetDeadAnimation();
    }

}
