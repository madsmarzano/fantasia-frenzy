using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoltBehavior : MonoBehaviour
{
    EnemyHealth enemy;
    public float damage;

    public bool isTouchingEnemy = false;
    public bool isAttacking = false;

    private void Update()
    {
        if (isTouchingEnemy && !isAttacking)
        {
            StartCoroutine(DamageEnemy());
        }
        else
        {
            StopCoroutine(DamageEnemy()); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            enemy = collision.GetComponent<EnemyHealth>();
            isTouchingEnemy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingEnemy = false;
    }

    IEnumerator DamageEnemy() 
    {
        isAttacking = true;
        enemy.health -= damage;
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }
}
