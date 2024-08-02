using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAttack : FSMAction
{
    [Header("Config")]
    [SerializeField] private float enemyDamage;
    [SerializeField] private float timeBtwAttacks; //attack speed

    private EnemyBrain enemyBrain;
    private float timer = 0f;


    private void Awake()
    {
        enemyBrain = GetComponent<EnemyBrain>();
    }

    public override void Act()
    {
        AttackPlayer();
    }

    private void AttackPlayer()
    {
        if (enemyBrain.Player == null) return;
        timer -= Time.deltaTime;
        PlayerHealth playerHealth = enemyBrain.Player?.GetComponent<PlayerHealth>();
        if (timer <= 0f)
        {
            if (!playerHealth.IsPlayerDead)
            {
                playerHealth.TakeDamage(enemyDamage);
                timer = timeBtwAttacks;
            }
        }
    }
}
