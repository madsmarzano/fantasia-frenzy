using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 10f;

    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Material flashMaterial;
    [SerializeField] private Material originalMaterial;

    private Animator animator;
    private Coroutine _damageEffect;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = _spriteRenderer.material;
    }

    private void Update()
    {
        if (health == 0f)
        {
            EnemyDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (_damageEffect != null)
            {
                StopCoroutine(_damageEffect);
            }
            _damageEffect = StartCoroutine(DamageEffect());
        }
    }

    IEnumerator DamageEffect()
    {
        _spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(0.15f);
        _spriteRenderer.material = originalMaterial;
        _damageEffect = null;
    }

    private void EnemyDeath()
    {
        gameObject.SetActive(false);
        //animator.Play("Death");
    }
}
