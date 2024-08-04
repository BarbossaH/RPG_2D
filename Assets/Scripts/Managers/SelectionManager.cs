using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static event Action<EnemyBrain> OnEnemySelectedEvent;
    public static event Action OnNoSelectionEvent;
    [Header("Config")]
    [SerializeField] private LayerMask enemyMask;

    private Camera mainCamera;//for get mouse point position

    private void Awake()
    {
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
                    // if (enemyBrain.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
                    // {
                    //     enemyHealth.TakeDamage(0);
                    // }
                    EnemyHealth health = enemyBrain.GetComponent<EnemyHealth>();
                    if (health.CurrentHealth <= 0) return;
                    //when clicking a game object, the object clicked will show the sprite, and the other sprite will disappear.
                    OnEnemySelectedEvent?.Invoke(enemyBrain);

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
