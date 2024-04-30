using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gdawg : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public float damage;

    [SerializeField] PlayerHealthValue pHealth;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetVelocity();
        SetDestroyTime();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            pHealth.value -= damage;
            Destroy(gameObject);
        }
    }
    private void SetVelocity()
    {
        rb.velocity = Vector2.left * speed;
    }
    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }
}
