using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionWander : FSMAction
{
    [Header("Config")]
    [SerializeField] private float speed;
    [SerializeField] private float wanderTime;
    [SerializeField] private float moveRadius;

    private Vector3 spawnPosition;

    private Vector3 movePosition; //to store the next position to be moved to
    private Vector3 moveDir;
    private float timer; // to control wander time variable
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        timer = wanderTime;
        spawnPosition = transform.position;
        GetNewDestinationPosition();
    }
    public override void Act()
    {
        timer -= Time.deltaTime;
        //move to destination
        // Vector3 moveDir = (movePosition - transform.position).normalized;
        Vector3 movement = moveDir * (speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePosition) >= 0.5f)
        {
            // transform.Translate(movement);
            rb.MovePosition(transform.position + movement);
        }

        if (timer <= 0)
        {
            GetNewDestinationPosition();
            timer = wanderTime;
        }
    }

    private void GetNewDestinationPosition()
    {
        float randomX = Random.Range(-moveRadius, moveRadius);
        float randomY = Random.Range(-moveRadius, moveRadius);
        //because the direction used normalized as the multiplier
        movePosition = spawnPosition + new Vector3(randomX, randomY);
        moveDir = (movePosition - transform.position).normalized;
    }

    private void OnDrawGizmosSelected()
    {
        if (moveRadius != 0)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, moveRadius * 2);
            Gizmos.DrawLine(transform.position, movePosition);
        }
    }
}
