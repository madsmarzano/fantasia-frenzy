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
    private bool isWaiting = false;

    private Animator animator;
    private new CapsuleCollider2D collider;

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

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Mouth Open") && !isWaiting)
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
        isUp = false;
    }

    private void Attack()
    {
        GameObject slimeProjectile = Instantiate(projectile, projectileSpawnPoint.transform.position, Quaternion.identity);
        isWaiting = true;
    }
}
