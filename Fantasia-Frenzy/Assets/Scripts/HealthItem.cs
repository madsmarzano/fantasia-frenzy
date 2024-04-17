using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private PlayerHealthValue health;
    [SerializeField] private float healthIncrease;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RestoreHealth();
            Destroy(this.gameObject);
        }
    }

    void RestoreHealth()
    {
        for (int i = 0; i < healthIncrease && health.value < health.maxHealth; i++)
        {
            health.value++;
        }
    }
}
