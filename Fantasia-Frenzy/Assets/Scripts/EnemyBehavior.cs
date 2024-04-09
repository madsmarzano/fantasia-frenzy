using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float health = 10f;
    public float damage = 1f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health == 0f)
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        gameObject.SetActive(false);
        //animator.Play("Death");
    }
}
