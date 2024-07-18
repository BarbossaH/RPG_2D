using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private readonly int moveX = Animator.StringToHash("MoveX");
    private readonly int moveY = Animator.StringToHash("MoveY");
    private readonly int isMoving = Animator.StringToHash("IsMoving");
    private readonly int triggerDead = Animator.StringToHash("Dead");
    private readonly int triggerRevive = Animator.StringToHash("Revive");
    private Animator anim;

    private void Awake()
    {

        anim = GetComponent<Animator>();
    }

    public void SetDeadAnimation()
    {
        anim.SetTrigger(triggerDead);
    }
    public void SetMoveAnimation(bool value, Vector2 dir)
    {
        anim.SetBool(isMoving, value);
        if (value)
        {
            SetMoveDirection(dir);
        }
    }
    public void ResetAnimation()
    {
        SetMoveDirection(Vector2.down);
        anim.SetTrigger(triggerRevive);
    }
    private void SetMoveDirection(Vector2 dir)
    {
        anim.SetFloat(moveX, dir.x);
        anim.SetFloat(moveY, dir.y);
    }
}
