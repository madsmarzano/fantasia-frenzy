using System.Collections;
using UnityEngine;

public class Gangstalishouhs : MonoBehaviour
{
    private Transform target;
    public float attackRange;
    [SerializeField] GameObject bulletSpawnPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] PlayerHealthValue playerHealth;
    [SerializeField] private int damage;
    private bool isShooting = false;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < attackRange && !isShooting)
        { StartCoroutine(Shoot()); }
    }

    IEnumerator Shoot()
    { isShooting = true;
        Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        isShooting = false;
    }
}
