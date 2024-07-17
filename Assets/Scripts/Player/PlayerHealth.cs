using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerStatus playerStatus;
    private PlayerAnimations playerAnimations;

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1);
        }
    }
    public void TakeDamage(float damage)
    {
        playerStatus.CurrentHealth -= damage;
        if (playerStatus.CurrentHealth <= 0)
        {
            PlayerDead();
        }
    }

    private void PlayerDead()
    {
        playerAnimations.SetDeadAnimation();
    }

}
