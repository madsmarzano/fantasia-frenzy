using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareCleanup : MonoBehaviour
{
    private void Update()
    {
        if (transform.childCount < 3)
        {
            Destroy(gameObject);
        }
    }
}
