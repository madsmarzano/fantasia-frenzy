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

    private Vector2 newPos;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Vector2 newPos = new Vector2(runDistance, transform.position.y);
        Vector2 targetPos = new Vector2 (target.position.x, transform.position.y);
        if (Vector2.Distance(transform.position, target.position) < attackDistance)
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
}
