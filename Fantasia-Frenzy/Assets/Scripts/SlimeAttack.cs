using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    public int projectileHealth;
    public int speed;
    public int damage;

    //private int shootDirection;
    private Rigidbody2D rb;
    public Transform target;

    private Vector2 shootDirection => target.transform.localScale.x > gameObject.transform.localScale.x ? Vector2.right : Vector2.left; //checks if player is to right or left of slime

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SetVelocity();
    }

    void SetVelocity()
    {
        rb.velocity = shootDirection * speed;
    }
}
