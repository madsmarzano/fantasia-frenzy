using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;

    private GameObject bulletInst;

    [SerializeField] Animator animator;

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;

    private void Update()
    {
        HandleGunRotation();
    }

    private void HandleGunRotation()
    {
        //rotate gun towards mouse position
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;

        gun.transform.right = direction; //controls rotation of the gun

        //flip the gun when it reaches 90 degrees
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 localScale = Vector3.one;

        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }

        gun.transform.localScale = localScale;
    }
}

