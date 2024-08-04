using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    public Vector3 Direction { get; set; }

    private void Start()
    {
        Direction = Vector3.up;
    }
    private void Update()
    {
        ProjectileMove();
    }

    private void ProjectileMove()
    {
        transform.Translate(Direction * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        // Debug.Log("Collision");
    }
}
