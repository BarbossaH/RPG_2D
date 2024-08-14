using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : Singleton<SelectionManager>
{
    public static event Action<EnemyBrain> OnEnemySelectedEvent;
    public static event Action OnNoSelectionEvent;
    [Header("Config")]
    [SerializeField] private LayerMask enemyMask;

    private Camera mainCamera;//for get mouse point position

    protected override void Awake()
    {
        base.Awake();
        mainCamera = Camera.main;
    }
    private void Update()
    {
        SelectEnemy();
    }
    private void SelectEnemy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, enemyMask);
            if (hit2D.collider != null)
            {
                EnemyBrain enemyBrain = hit2D.collider.GetComponent<EnemyBrain>();
                if (enemyBrain != null)
                {
                    EnemyHealth health = enemyBrain.GetComponent<EnemyHealth>();
                    if (health.CurrentHealth <= 0)
                    {
                        EnemyLoot enemyLoot = enemyBrain.GetComponent<EnemyLoot>();
                        LootManager.Instance.ShowLoot(enemyLoot);
                    }
                    else
                    {
                        //when clicking a game object, the object clicked will show the sprite, and the other sprite will disappear.
                        OnEnemySelectedEvent?.Invoke(enemyBrain);
                    }
                }
            }
            else
            {
                //if clicking nothing, the sprite will disappear
                OnNoSelectionEvent?.Invoke();
            }
        }
    }
}
