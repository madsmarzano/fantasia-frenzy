using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Value")]
public class WeaponValue : ScriptableObject
{
    public int current;
    public int selected;

    public void ResetValue()
    {
        current = 0;
    }
}
