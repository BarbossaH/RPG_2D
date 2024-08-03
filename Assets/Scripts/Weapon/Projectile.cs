using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    public Vector3 Direction { get; set; }

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
        Debug.Log("Collision");
    }
}
