using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float normalBulletSpeed = 15f;
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private LayerMask whatDestroysBullet;

    public float damage = 1f;

    private EnemyBehavior enemy;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyBehavior>();

        SetStraightVelocity();
        SetDestroyTime();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //is the collision in the whatDestroysBullet LayerMask
        if ((whatDestroysBullet.value & (1 << collision.gameObject.layer)) > 0)
        {
            //spawn particles

            //screen shake

            //damage enemy
            if (collision.CompareTag("Enemy"))
            {
                enemy = collision.GetComponent<EnemyBehavior>();
                enemy.enemyHealth = enemy.enemyHealth - damage;
            }

            //destroy bullet
            Destroy(gameObject);
        }
    }

    private void SetStraightVelocity()
    {
        rb.velocity = transform.right * normalBulletSpeed;
    }

    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }

}
