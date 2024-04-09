using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LittleDemon : MonoBehaviour
{
    public float speed;
    public float runDistance;
    public Transform target;
    public float attackDistance;

    private bool isHolding = false;

    private Vector2 newPos;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetDirection();

        Vector2 targetPos = new Vector2 (target.position.x * runDistance, transform.position.y);
        if (Vector2.Distance(transform.position, target.position) < attackDistance)
        {
            //Charge();

            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            //isHolding = true;
        }
    }

    private void GetDirection()
    {
        if (target.position.x < transform.position.x)
        {
            //enemy moves left
            runDistance = -2f;
        }
        else if (target.position.x > transform.position.x)
        {
            //enemy moves right
            runDistance = 2f;
        }
    }

    private void Charge()
    {
        //transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        //transform.position = new Vector2(target.position.x * overshoot, transform.position.y);
        if (target.position.x < transform.position.x)
        {
            //enemy moves left
            newPos = new Vector2(-runDistance, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
        }
        else if (target.position.x > transform.position.x)
        {
            //enemy moves right
            newPos = new Vector2(runDistance, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
        }
    }
}
