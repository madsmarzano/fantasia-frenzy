using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightmare : MonoBehaviour
{
    public float floatSpeed = 3f;
    public bool isDead = false;
    private EnemyHealth enemyHealth;

    Rigidbody2D rb;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (enemyHealth.health == 0)
        {
            isDead = true;
            rb.velocity = new Vector2(rb.velocity.x, floatSpeed * Vector2.down.x);
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            //Nightmare moves
            rb.velocity = new Vector2(floatSpeed * Vector2.left.x, rb.velocity.y);
        }
    }
}
