using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionCheck : MonoBehaviour
{

    public bool isTouchingBox = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WeaponBox"))
        {
            isTouchingBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("WeaponBox"))
        {
            if (isTouchingBox)
            {
                isTouchingBox = false;
            }
        }
    }
}
