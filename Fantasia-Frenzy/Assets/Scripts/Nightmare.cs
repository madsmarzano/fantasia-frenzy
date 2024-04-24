using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Nightmare : MonoBehaviour
{
    public float floatSpeed = 3f;
    public Transform pointA;
    public Transform pointB;
    public float damage = 10f;

    private Vector3 nextPosition;

    private bool isAttacking = false;
    private bool isWaiting = false;

    [SerializeField] private PlayerHealthValue _playerHealth;

    private GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        nextPosition = pointA.position;
    }

    private void FixedUpdate()
    {
        {
            if (!isAttacking)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPosition, floatSpeed * Time.deltaTime);
            }

            if (transform.position == nextPosition)
            {
                nextPosition = (nextPosition == pointA.position) ? pointB.position : pointA.position;
                FlipSprite();
            }

            if (isAttacking && !isWaiting)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, floatSpeed * 2f * Time.deltaTime);
                FlipSprite();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") || collision.CompareTag("Bolt"))
        {
            isAttacking = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerHealth.value -= damage;
            StartCoroutine(AttackWait());
        }
    }

    IEnumerator AttackWait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(0.5f);
        isWaiting = false;
    }

    private void FlipSprite()
    {
        Vector3 localScale = Vector3.one;

        if (!isAttacking)
        {
            if (nextPosition.x < transform.position.x){
                localScale.x = 1;
                transform.localScale = localScale;
            } else if (nextPosition.x > transform.position.x) {
                localScale.x = -1;
                transform.localScale = localScale;
            }
        }
        if (isAttacking)
        {
            if (target.transform.position.x < transform.position.x){
                localScale.x = 1;
                transform.localScale = localScale;
            } else if (target.transform.position.x > transform.position.x) {
                localScale.x = -1;
                transform.localScale = localScale;
            }
        }
    }


}
