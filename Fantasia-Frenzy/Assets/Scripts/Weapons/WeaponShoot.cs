using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bolt;
    [SerializeField] GameObject bulletSpawnPoint;

    //private bool boltActive = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && this.CompareTag("Projectile"))
            Shoot();

        if (Input.GetMouseButtonDown(0) && this.CompareTag("Bolt"))
            Bolt();
    }

    private void Shoot()
    {
        //spawn bullet
        GameObject bulletInst = Instantiate(bullet, bulletSpawnPoint.transform.position, this.transform.rotation);
        animator.Play("Shoot", 0);

    }

    private void Bolt()
    {
        if (transform.childCount == 0) //checks if there is already an active instance of the bolt
        {
            GameObject boltInst = Instantiate(bolt, this.transform.position, this.transform.rotation, this.transform);
            Destroy(boltInst, 2f);
        }

    }
}
