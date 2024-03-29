using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float enemyHealth = 10f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (enemyHealth == 0f)
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        animator.Play("Death");
    }
}
