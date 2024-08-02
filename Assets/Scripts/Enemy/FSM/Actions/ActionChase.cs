using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionChase : FSMAction
{
    [Header("Config")]
    [SerializeField] private float chaseSpeed;

    private EnemyBrain enemyBrain;

    private void Awake()
    {
        enemyBrain = GetComponent<EnemyBrain>();
    }
    public override void Act()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        if (enemyBrain.Player == null) return;
        Vector3 distance = enemyBrain.Player.position - transform.position;
        Vector3 directionToPlayer = distance.normalized;
        if (distance.magnitude >= 1.3f)
        {
            transform.Translate(directionToPlayer * (chaseSpeed * Time.deltaTime));
        }
    }
}
