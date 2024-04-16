using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collectable Count")]

public class CollectableCount : ScriptableObject
{
    public float count;

    public void Reset()
    {
        count = 0;
    }
}
