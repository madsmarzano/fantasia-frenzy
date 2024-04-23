using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 10f;

    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Material flashMaterial;
    private Material originalMaterial;

    [SerializeField] EnemyKillCount enemiesDefeated;
    [SerializeField] GameObject healthItem;

    private Coroutine _damageEffect;
    private Coroutine _boltEffect;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = _spriteRenderer.material;
        enemiesDefeated.Reset();
    }

    private void Update()
    {
        if (health == 0f)
        {
            EnemyDeath();
            ItemDrop();
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

        if (other.CompareTag("Bolt"))
        {
            _spriteRenderer.material = flashMaterial;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _spriteRenderer.material = originalMaterial;
    }

    public IEnumerator DamageEffect()
    {
        _spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(0.15f);
        _spriteRenderer.material = originalMaterial;
        _damageEffect = null;
    }

    public IEnumerator BoltEffect()
    {
        _spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(0.15f);
        _spriteRenderer.material = originalMaterial;
        _damageEffect = null;
    }

    private void EnemyDeath()
    {
        Destroy(gameObject);
        enemiesDefeated.count++;
    }

    private void ItemDrop()
    {
        if ((enemiesDefeated.count % 5) == 0)
        {
            Instantiate(healthItem, transform.position, Quaternion.identity);
        }
    }
}
