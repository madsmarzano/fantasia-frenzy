using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDemon : MonoBehaviour
{
    private Transform target;
    public float attackRange;
    [SerializeField] GameObject projectileSpawnPoint; //child object of SlimeDemon
    [SerializeField] GameObject projectile;

    private bool isUp = false;
    private bool isAttacking = false;

    private Animator animator;
    private new CapsuleCollider2D collider;

    [SerializeField] PlayerHealthValue playerHealth;
    [SerializeField] private int damage;

    private void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        collider.enabled = false;
    }

    private void Update()
    {

        if (Vector2.Distance(transform.position, target.position) < attackRange && !isUp)
        {
            PopUp();
        }
        else if (Vector2.Distance(transform.position, target.position) > attackRange && isUp)
        {
            Retract();
        }

        //If animation of mouth opening has finished playing, start Attack
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Mouth Open") && !isAttacking)
        {
            Attack();
        }
    }

    private void PopUp()
    {
        animator.Play("Popup");
        collider.enabled = true;
        isUp = true;
    }

    private void Retract()
    {
        animator.Play("Retract");
        collider.enabled = false;
        isUp = false;
    }

    private void Attack()
    {
        isAttacking = true;
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        Instantiate(projectile, projectileSpawnPoint.transform.position, Quaternion.identity); //spawns the projectile
        animator.Play("Mouth Close");
        yield return new WaitForSecondsRealtime(3f);
        animator.Play("Mouth Open");
        yield return new WaitForSeconds(1f);
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
