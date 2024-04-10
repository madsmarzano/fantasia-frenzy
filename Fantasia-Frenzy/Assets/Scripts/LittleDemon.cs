using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LittleDemon : MonoBehaviour
{
    public float speed;
    public float attackDistance;

    public bool inRange = false;
    private bool isAttacking = false;

    private Vector2 direction;
    private Rigidbody2D rb;
    private Transform enemy;
    private Transform target;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GetDirection();
    }

    private void Update()
    {

        if (Vector2.Distance(enemy.position, target.position) < attackDistance)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        if (inRange && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    private void GetDirection()
    {
        if (target.position.x < enemy.position.x)
        {
            //enemy moves left
            direction = Vector2.left;
        }
        else if (target.position.x > enemy.position.x)
        {
            //enemy moves right
            direction = Vector2.right;
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        rb.velocity = direction * speed;
        yield return new WaitForSecondsRealtime(3);
        GetDirection();
        isAttacking = false;
    }
}
