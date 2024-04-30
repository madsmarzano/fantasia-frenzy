using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretElevator : MonoBehaviour
{
    public GameObject _secretElevator;

    private void Update()
    {
        if (transform.childCount == 0)
        {
            _secretElevator.SetActive(true);
            Destroy(gameObject);
        }
    }
}
