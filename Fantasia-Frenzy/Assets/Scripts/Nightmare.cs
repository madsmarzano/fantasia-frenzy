using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Nightmare : MonoBehaviour
{
    public float floatSpeed = 3f;
    public Transform pointA;
    public Transform pointB;

    private Vector3 nextPosition;

    public bool isDead = false;
    private EnemyHealth enemyHealth;

    private bool isAttacking= false;
    [SerializeField] private GameObject lightning;
    public float distance;

    Rigidbody2D rb;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        nextPosition = pointA.position;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
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
        }

        Physics2D.queriesStartInColliders = false;
        if (!isDead)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);
            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);

            if (hit.collider.CompareTag("Player") && !isAttacking)
            {
                //isAttacking = true;
                StartCoroutine(Attack());
            }
        }

        if (enemyHealth.health == 0)
        {
            isDead = true;
            rb.velocity = new Vector2(rb.velocity.x, floatSpeed * Vector2.down.x);
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        GameObject lightningInst = Instantiate(lightning, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        isAttacking = false;
    }


}
