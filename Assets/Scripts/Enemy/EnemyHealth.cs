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
    private EnemySelector enemySelector;

    public static event Action OnEnemyDieEvent;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<EnemyBrain>();
        enemySelector = GetComponent<EnemySelector>();
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
            anim.SetTrigger(triggerDeath);
            enemy.enabled = false;
            enemySelector.DisableSelection();
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            OnEnemyDieEvent?.Invoke();
        }
        else
        {
            // DamageTextManger.Instance.ShowDamageText(damage, transform);
        }
    }
}
