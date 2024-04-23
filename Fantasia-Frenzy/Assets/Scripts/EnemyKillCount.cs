using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Kill Count")]

public class EnemyKillCount : ScriptableObject
{
    public float count;

    public void Reset()
    {
        count = 0;
    }
}
