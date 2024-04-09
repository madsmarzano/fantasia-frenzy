using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDemon : MonoBehaviour
{
    public Transform target;
    public float attackRange;
    [SerializeField] GameObject projectileSpawnPoint;
    [SerializeField] GameObject projectile;

    private bool isUp = false;
    private bool isWaiting = false;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
