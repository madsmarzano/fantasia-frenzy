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

    [SerializeField] float waitTime = 0;
    [SerializeField] float reloadTime;
    [SerializeField] float magCount;
    private float fullMag;

    private bool isShooting = false;
    private bool isResetting = false;

    //private bool boltActive = false;

    private void Start()
    {
        fullMag = magCount;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && this.CompareTag("Projectile") && !isShooting)
            StartCoroutine(Shoot());

        if (Input.GetMouseButton(0) && this.CompareTag("FullAuto") && !isShooting && magCount > 0)
            StartCoroutine(FullAuto());

        if (Input.GetMouseButtonDown(0) && this.CompareTag("Bolt"))
            Bolt();

        if (magCount == 0 && !isResetting)
        {
            StartCoroutine(ResetMag());
        }
    }

    IEnumerator Shoot()
    {
        //spawn bullet
        isShooting = true;
        GameObject bulletInst = Instantiate(bullet, bulletSpawnPoint.transform.position, this.transform.rotation);
        animator.Play("Shoot", 0);
        yield return new WaitForSeconds(waitTime);
        isShooting = false;

    }

    IEnumerator FullAuto()
    {
        //spawn bullet
        isShooting = true;
        GameObject bulletInst = Instantiate(bullet, bulletSpawnPoint.transform.position, this.transform.rotation);
        animator.Play("Shoot", 0);
        magCount--;
        yield return new WaitForSeconds(waitTime);
        isShooting = false;
    }

    IEnumerator ResetMag()
    {
        isResetting = true;
        yield return new WaitForSeconds(reloadTime);
        magCount = fullMag;
        isResetting = false;

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
