using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float speed;
    private Player player;

    private PlayerAnimations playerAnimations;
    private Rigidbody2D rb2D;
    private PlayerActions actions;
    private Vector2 moveDirection;
    public Vector2 MoveDirection => moveDirection;

    private void Awake()
    {
        player = GetComponent<Player>();
        actions = new PlayerActions();
        rb2D = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        ReadMovementInActions();
    }
    private void FixedUpdate()
    {
        if (player.PlayerStatus.CurrentHealth <= 0) return;
        Move();
    }
    private void Move()
    {
        rb2D.MovePosition((rb2D.position + moveDirection * (speed * Time.fixedDeltaTime)));

    }
    private void ReadMovementInActions()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
        playerAnimations.SetMoveAnimation(moveDirection != Vector2.zero, moveDirection);

        // Debug.Log(moveDirection);
    }
    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
