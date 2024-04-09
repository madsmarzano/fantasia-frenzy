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

    private bool isAttacking = false;

    private Vector2 newPos;
    private Vector3 targetPos;

    private void Start()
    {
        GetDirection();
        targetPos = new Vector3(transform.position.x * runDistance, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        GetDirection();

        //Vector2 targetPos = new Vector2 (transform.position.x * runDistance, transform.position.y);
        if (Vector2.Distance(transform.position, target.position) < attackDistance)
        {
            //Charge();
            isAttacking = true;
            while (isAttacking)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                if (transform.position == targetPos)
                {
                    isAttacking = false; break;
                }
            }
            //isHolding = true;
        }
    }

    private void GetDirection()
    {
        if (target.position.x < transform.position.x)
        {
            //enemy moves left
            runDistance = 2f;
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
