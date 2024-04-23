using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    public int projectileHealth;
    public int speed;
    public int damage;
    [SerializeField] private float destroyTime;

    private Rigidbody2D rb;
    private Vector2 shootDirection;
    private Vector2 worldPosition;
    private Transform target;

    [SerializeField] PlayerHealthValue playerHealth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //shootDirection = target.position.x < transform.position.x ? Vector2.left : Vector2.right; //checks if player is to right or left of slime
        shootDirection = target.transform.position;
        //SetVelocity();
        SetDestroyTime();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, shootDirection, speed * Time.deltaTime);
    }


    void SetVelocity()
    {
        //rb.velocity = shootDirection * speed;
        rb.velocity = Vector2.right * speed;
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
