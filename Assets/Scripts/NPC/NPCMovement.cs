using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float moveSpeed;
    private readonly int moveX = Animator.StringToHash("MoveX");
    private readonly int moveY = Animator.StringToHash("MoveY");
    private Waypoint waypoint;
    private Animator anim;
    private Vector3 previousPos;
    private int currentPointIndex;
    private bool isTurn;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        waypoint = GetComponent<Waypoint>();
    }
    private void Update()
    {
        Vector3 nextPos = waypoint.GetPosition(currentPointIndex);
        UpdateMoveValues(nextPos);
        transform.position = Vector3.MoveTowards(transform.position, nextPos, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, nextPos) < 0.2f)
        {
            previousPos = nextPos;
            if (!isTurn)
            {
                currentPointIndex++;
                if (currentPointIndex >= waypoint.Points.Length - 1)
                {
                    // currentPointIndex = 0;
                    isTurn = true;
                }
            }
            else
            {
                currentPointIndex--;

                if (currentPointIndex <= 0)
                {
                    // currentPointIndex = waypoint.Points.Length - 1;
                    isTurn = false;

                }
            }

        }
    }
    private void UpdateMoveValues(Vector3 nextPos)
    {
        Vector2 dir = Vector2.zero;

        if (Mathf.Abs(previousPos.x - nextPos.x) >= Mathf.Abs(previousPos.y - nextPos.y))
        {
            //it means the distance in x axis is greater than in y
            if (previousPos.x < nextPos.x) dir = new Vector2(1f, 0f);
            if (previousPos.x > nextPos.x) dir = new Vector2(-1f, 0f);
        }
        else
        {
            if (previousPos.y < nextPos.y) dir = new Vector2(0f, 1f);
            if (previousPos.y > nextPos.y) dir = new Vector2(0f, -1f);
        }
        anim.SetFloat(moveX, dir.x);
        anim.SetFloat(moveY, dir.y);
    }
}
