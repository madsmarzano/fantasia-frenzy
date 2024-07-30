using System.Collections;
using UnityEngine;

/// <summary>
/// by Madison Marzano
/// 
/// Controls the behavior of the LittleDemon enemy. 
/// If player is within range of enemy, enemy charges at the player. 
/// </summary>

public class LittleDemon : MonoBehaviour
{
    public float speed;
    public float attackDistance;
    public int damage = 10;

    public bool inRange = false;
    private bool isAttacking = false;

    private bool isActive = false;

    private Vector2 direction;
    private Rigidbody2D rb;
    private Transform enemy;
    private Transform target;

    [SerializeField] PlayerHealthValue playerHealth;

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
            isActive = true;
            StartCoroutine(Attack());
        }

        if (isActive && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    private void GetDirection()
    {
        Vector3 localScale = Vector3.one;

        if (target.position.x < enemy.position.x)
        {
            //enemy moves left
            localScale.x = 1;
            transform.localScale = localScale;
            direction = Vector2.left;
        }
        else if (target.position.x > enemy.position.x)
        {
            //enemy moves right
            localScale.x = -1;
            transform.localScale = localScale;
            direction = Vector2.right;
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        rb.velocity = direction * speed; //moves enemy in direction of the player
        yield return new WaitForSecondsRealtime(3); //waits 3 seconds before attacking again if Player is still in range
        GetDirection(); //checks for new player direction
        isAttacking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.value -= damage;
        }
    }
}
