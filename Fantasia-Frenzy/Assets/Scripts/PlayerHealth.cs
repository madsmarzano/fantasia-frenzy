using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerHealthValue health;
    public float currentHealth; //DELETE LATER

    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Material flashMaterial;
    [SerializeField] private Material originalMaterial;

    public GameOverScreen gameOverScreen;

    private Coroutine _damageEffect;

    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        originalMaterial = _spriteRenderer.material;

        health.ResetHealth();
    }

    private void Update()
    {
        currentHealth = health.value;

        if (health.value <= 0)
        {
            //GAME OVER
            GameOver();
        }
    }

    private void GameOver()
    {
        //Scene currentScene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene("Game Over");
        gameOverScreen.Setup();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyProjectile" || collision.gameObject.tag == "Hazard")
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
