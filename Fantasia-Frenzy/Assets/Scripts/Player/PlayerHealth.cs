using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    [SerializeField] private int maxHealth;

    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Material flashMaterial;
    [SerializeField] private Material originalMaterial;

    private Coroutine _damageEffect;

    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        originalMaterial = _spriteRenderer.material;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
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

}
