using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttackShane : MonoBehaviour
{
    public int projectileHealth;
    public int speed;
    public int damage;
    [SerializeField] private float destroyTime;

    private Rigidbody2D rb;
    private Vector2 shootDirection;
    private Transform target;

    [SerializeField] PlayerHealthValue playerHealth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        shootDirection = target.position.x < transform.position.x ? Vector2.left : Vector2.right; //checks if player is to right or left of slime

        SetVelocity();
        SetDestroyTime();
    }


    void SetVelocity()
    {
        rb.velocity = shootDirection * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.value -= damage;
            Destroy(gameObject);
        }
    }
    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }

}