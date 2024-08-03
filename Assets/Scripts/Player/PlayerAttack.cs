using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float attackSpeed;
    private PlayerActions actions;
    private PlayerAnimations playerAnimations;
    private EnemyBrain enemyTarget;

    private Coroutine attackCoroutine;

    private void Awake()
    {
        actions = new PlayerActions();
        playerAnimations = GetComponent<PlayerAnimations>();
    }
    private void Start()
    {
        actions.Attack.ClickAttack.performed += ctx => AttackEnemy();
    }

    private void AttackEnemy()
    {
        if (enemyTarget != null)
        {
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
            }
            attackCoroutine = StartCoroutine(IEAttack());
        }
    }

    private IEnumerator IEAttack()
    {
        playerAnimations.SetAttackAnimation(true);
        yield return new WaitForSeconds(attackSpeed);
        playerAnimations.SetAttackAnimation(false);
    }

    private void OnEnable()
    {
        actions.Enable();
        SelectionManager.OnEnemySelectedEvent += EnemySelectCallback;
        SelectionManager.OnNoSelectionEvent += NoEnemySelectCallback;
    }

    private void NoEnemySelectCallback()
    {
        enemyTarget = null;
    }

    private void EnemySelectCallback(EnemyBrain enemySelected)
    {
        enemyTarget = enemySelected;
    }

    private void OnDisable()
    {
        actions.Disable();
        SelectionManager.OnEnemySelectedEvent -= EnemySelectCallback;
        SelectionManager.OnNoSelectionEvent -= NoEnemySelectCallback;
    }
}
