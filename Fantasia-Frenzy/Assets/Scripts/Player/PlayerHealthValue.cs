using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Health Value")]
public class PlayerHealthValue : ScriptableObject
{
    public float value;
    public float maxHealth = 100f;

    public void ResetHealth()
    {
        value = maxHealth;
    }
}
