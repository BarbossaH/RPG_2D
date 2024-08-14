using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [Header("Config")]
    [SerializeField] private float health;
    public float CurrentHealth { get; private set; }
    private readonly int triggerDeath = Animator.StringToHash("triggerDeath");
    private Animator anim;
    private EnemyBrain enemy;
    private EnemyLoot enemyLoot;
    private EnemySelector enemySelector;
    private Rigidbody2D rb2d;
    public static event Action OnEnemyDieEvent;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<EnemyBrain>();
        enemyLoot = GetComponent<EnemyLoot>();
        enemySelector = GetComponent<EnemySelector>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        CurrentHealth = health;
    }
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        DamageTextManger.Instance.ShowDamageText(damage, transform);
        if (CurrentHealth <= 0f)
        {
            DisableEnemy();
        }
        else
        {
            // DamageTextManger.Instance.ShowDamageText(damage, transform);
        }
    }

    private void DisableEnemy()
    {
        anim.SetTrigger(triggerDeath);
        enemy.enabled = false;
        enemySelector.DisableSelection();
        // gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        rb2d.bodyType = RigidbodyType2D.Static;
        OnEnemyDieEvent?.Invoke();
        GameManager.Instance.AddPLayerExp(enemyLoot.ExpDrop);
    }
}
