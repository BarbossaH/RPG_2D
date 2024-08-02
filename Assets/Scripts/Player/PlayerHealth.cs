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
        // Debug.Log(playerStatus.CurrentHealth);
        if (playerStatus.CurrentHealth <= 0)
        {
            playerStatus.CurrentHealth = 0;
            PlayerDead();
        }
    }

    private void PlayerDead()
    {
        IsPlayerDead = true;
        playerAnimations.SetDeadAnimation();
    }

}
