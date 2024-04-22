using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltBehavior : MonoBehaviour
{
    EnemyHealth enemy;
    private Coroutine _damageEnemy;
    public float damage;
    public int attackCycles = 3;

    private SpriteRenderer enemySpriteRenderer;
    private Material originalMaterial;
    [SerializeField] private Material flashMaterial;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            enemy = collision.GetComponent<EnemyHealth>();
            enemySpriteRenderer = collision.GetComponent<SpriteRenderer>();
            originalMaterial = enemySpriteRenderer.material;
            if (_damageEnemy != null) {
                StopCoroutine(DamageEnemy(enemy, enemySpriteRenderer, originalMaterial));
            }
            _damageEnemy = StartCoroutine(DamageEnemy(enemy, enemySpriteRenderer, originalMaterial));
        }
    }

    IEnumerator DamageEnemy(EnemyHealth enemy, SpriteRenderer enemySpriteRenderer, Material originalMaterial) 
    {
        for (int i = 0; i < attackCycles; i++) {
            enemy.health = enemy.health - damage;
            enemySpriteRenderer.material = flashMaterial;
            yield return new WaitForSeconds(0.5f);
            enemySpriteRenderer.material = originalMaterial;
        }
        _damageEnemy = null;
    }
}
