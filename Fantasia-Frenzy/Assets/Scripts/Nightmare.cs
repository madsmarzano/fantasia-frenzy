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

    //private bool isDead = false;
    private bool isAttacking = false;
    private bool isWaiting = false;

    private EnemyHealth enemyHealth;
    [SerializeField] private PlayerHealthValue _playerHealth;

    [SerializeField] private GameObject lightning;
    private GameObject target;

    Rigidbody2D rb;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        enemyHealth = GetComponent<EnemyHealth>();
        nextPosition = pointA.position;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
            }

            if (isAttacking && !isWaiting)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, floatSpeed * 2f * Time.deltaTime);
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


}
