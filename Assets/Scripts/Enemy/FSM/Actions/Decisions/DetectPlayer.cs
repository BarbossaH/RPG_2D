using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : FSMDecision
{
    [Header("Config")]
    [SerializeField] private float detectRange;
    [SerializeField] private LayerMask playerMask;

    private EnemyBrain enemy;
    private void Awake()
    {
        enemy = GetComponent<EnemyBrain>();
    }
    public override bool Decide()
    {
        return FindPlayer();
    }

    private bool FindPlayer()
    {
        Collider2D playerCol = Physics2D.OverlapCircle(enemy.transform.position, detectRange, playerMask);
        enemy.Player = playerCol != null ? playerCol.transform : null;
        return playerCol != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
