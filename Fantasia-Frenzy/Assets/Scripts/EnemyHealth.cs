using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 10f;

    private SpriteRenderer _spriteRenderer;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (health == 0f)
        {
            EnemyDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            StartCoroutine(DamageEffect());
        }
    }

    IEnumerator DamageEffect()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        yield return null;
    }

    private void EnemyDeath()
    {
        gameObject.SetActive(false);
        //animator.Play("Death");
    }
}
