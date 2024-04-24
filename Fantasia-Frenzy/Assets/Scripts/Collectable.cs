using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float value = 1;
    [SerializeField] CollectableCount cheep;

    [SerializeField] GameObject _weaponBox;

    private void Start()
    {
        cheep.Reset();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            cheep.count += value;

            if ((cheep.count % 10) == 0)
            {
                SpawnWeaponBox();
            }
        }
    }

    void SpawnWeaponBox()
    {
        Instantiate(_weaponBox, new Vector2(transform.position.x - 5 , transform.position.y + 2), Quaternion.identity);
    }
}
