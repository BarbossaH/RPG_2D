using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float speed;

    private readonly int moveX = Animator.StringToHash("MoveX");
    private readonly int moveY = Animator.StringToHash("MoveY");
    private readonly int isMoving = Animator.StringToHash("IsMoving");
    private Rigidbody2D rb2D;
    private PlayerActions actions;
    private Vector2 moveDirection;
    private Animator anim;

    private void Awake()
    {
        actions = new PlayerActions();
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ReadMovementInActions();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        rb2D.MovePosition((rb2D.position + moveDirection * (speed * Time.fixedDeltaTime)));

    }
    private void ReadMovementInActions()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
        if (moveDirection != Vector2.zero)
        {
            anim.SetBool(isMoving, true);
            anim.SetFloat(moveX, moveDirection.x);
            anim.SetFloat(moveY, moveDirection.y);
        }
        else
        {
            anim.SetBool(isMoving, false);
        }
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
