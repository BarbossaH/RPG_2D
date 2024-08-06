using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public enum RotationAngel
{
    Up = 0,
    Right = -90,
    Left = 90,
    Down = -180
}
public class PlayerAttack : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private Weapon initialWeapon;
    [SerializeField] private Transform[] attackPos;
    [SerializeField] private float attackSpeed;
    [Header("Melee Config")]
    [SerializeField] private ParticleSystem slashFX;
    [SerializeField] private float minDistanceMeleeAttack;
    public Weapon CurrentWeapon { get; set; }

    private PlayerActions actions;
    private PlayerAnimations playerAnimations;
    private EnemyBrain enemyTarget;
    private PlayerMovement playerMovement;
    private PlayerMana playerMana;
    private Coroutine attackCoroutine;

    private Transform currentAttackPos;
    private float currentAttackRotation;


    private void Awake()
    {
        actions = new PlayerActions();
        playerMana = GetComponent<PlayerMana>();
        playerAnimations = GetComponent<PlayerAnimations>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Start()
    {
        actions.Attack.ClickAttack.performed += ctx => AttackEnemy();
        EquipWeapon(initialWeapon);
        // currentAttackPos = attackPos[0];
        // currentAttackRotation = (float)RotationAngel.Up;
    }
    private void Update()
    {
        GetFirePos();
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
        if (currentAttackPos != null)
        {
            playerAnimations.SetAttackAnimation(false);

            if (playerMana.CurrentMana < CurrentWeapon.RequiredMana) yield break;
            if (CurrentWeapon.type == WeaponType.Melee)
            {
                MeleeAttack();
            }
            else if (CurrentWeapon.type == WeaponType.Magic)
            {
                MagicAttack();
            }
        }
        playerAnimations.SetAttackAnimation(true);
        yield return new WaitForSeconds(attackSpeed);
        playerAnimations.SetAttackAnimation(false);
    }
    private void MagicAttack()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, currentAttackRotation));
        Projectile projectile = Instantiate(CurrentWeapon.projectilePrefab, currentAttackPos.position, rotation);
        // projectile.Direction = Vector3.up; //this place is very interesting, because the projectile object already has a rotation, so the 
        playerMana.UseMana(CurrentWeapon.RequiredMana);
        projectile.Damage = GetAttackDamage();
    }
    private void MeleeAttack()
    {
        slashFX.transform.position = currentAttackPos.position;
        slashFX.Play();
        float currentDistanceToEnemy = Vector3.Distance(enemyTarget.transform.position, transform.position);
        if (currentDistanceToEnemy <= minDistanceMeleeAttack)
        {
            enemyTarget.GetComponent<IDamageable>().TakeDamage(GetAttackDamage());
        }
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        CurrentWeapon = newWeapon;
        playerStatus.TotalDamage = playerStatus.BaseDamage + CurrentWeapon.Damage;
    }
    private float GetAttackDamage()
    {
        float damage = playerStatus.BaseDamage;
        damage += CurrentWeapon.Damage;
        float randomPercentage = Random.Range(0, 100f);
        if (randomPercentage <= playerStatus.CriticalChance)
        {
            damage += damage * (playerStatus.CriticalDamage / 100f);
        }
        return damage;
    }
    private void GetFirePos()
    {
        Vector2 moveDirection = playerMovement.MoveDirection;
        switch (moveDirection.x)
        {
            case > 0f:
                currentAttackPos = attackPos[1];
                currentAttackRotation = (float)RotationAngel.Right;
                break;
            case < 0f:
                currentAttackPos = attackPos[2];
                currentAttackRotation = (float)RotationAngel.Left;
                break;
        }
        switch (moveDirection.y)
        {
            case > 0f:
                currentAttackPos = attackPos[0];
                currentAttackRotation = (float)RotationAngel.Up;
                break;
            case < 0f:
                currentAttackPos = attackPos[3];
                currentAttackRotation = (float)RotationAngel.Down;
                break;
        }

    }
    private void OnEnable()
    {
        actions.Enable();
        SelectionManager.OnEnemySelectedEvent += EnemySelectCallback;
        SelectionManager.OnNoSelectionEvent += NoEnemySelectCallback;
        EnemyHealth.OnEnemyDieEvent += NoEnemySelectCallback;
    }

    private void OnDisable()
    {
        actions.Disable();
        SelectionManager.OnEnemySelectedEvent -= EnemySelectCallback;
        SelectionManager.OnNoSelectionEvent -= NoEnemySelectCallback;
        EnemyHealth.OnEnemyDieEvent -= NoEnemySelectCallback;

    }
    private void NoEnemySelectCallback()
    {
        enemyTarget = null;
    }

    private void EnemySelectCallback(EnemyBrain enemySelected)
    {
        enemyTarget = enemySelected;
    }
}
